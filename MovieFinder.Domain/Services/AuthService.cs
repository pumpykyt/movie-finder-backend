using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieFinder.Data;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Configs;
using MovieFinder.Domain.Exceptions;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Domain.Services;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly JwtConfig _jwtConfig;

    public AuthService(DataContext context, IOptions<JwtConfig> options)
    {
        _context = context;
        _jwtConfig = options.Value;
    }

    public async Task<string> RegisterAsync(string email, string password, string username)
    {
        var role = await _context.Roles
                                 .AsNoTracking()
                                 .SingleAsync(t => t.Value == "User");
        
        var userExists = await _context.Users
                                       .AsNoTracking()
                                       .AnyAsync(t => t.Email == email);
        
        if (userExists) throw new HttpStatusException(HttpStatusCode.Conflict, "Already registered");

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = username,
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Created = DateTime.UtcNow,
            RoleId = role.Id
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return GenerateJwt(user.Id, role.Value);
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _context.Users
                                 .AsNoTracking()
                                 .Include(t => t.Role)
                                 .SingleOrDefaultAsync(t => t.Email == email);

        if (user is null) throw new HttpStatusException(HttpStatusCode.NotFound, "User is not registered");

        var verified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        if (!verified) throw new HttpStatusException(HttpStatusCode.Unauthorized, "Bad credentials");

        return GenerateJwt(user.Email, user.Role.Value);
    }

    private string GenerateJwt(string userId, string role)
    {
        var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret));
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("id", userId),
                new("role", role)
            }),
            Expires = DateTime.UtcNow.AddDays(30),
            Issuer = _jwtConfig.Issuer,
            Audience = _jwtConfig.Audience,
            SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}
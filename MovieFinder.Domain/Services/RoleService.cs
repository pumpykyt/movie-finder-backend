using MovieFinder.Data;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Domain.Services;

public class RoleService : IRoleService
{
    private readonly DataContext _context;

    public RoleService(DataContext context)
    {
        _context = context;
    }

    public async Task<string> CreateRoleAsync(string name)
    {
        var role = new Role
        {
            Id = Guid.NewGuid().ToString(),
            Value = name
        };
        
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
        
        return role.Id;
    }
}
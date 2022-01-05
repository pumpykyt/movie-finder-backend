using MediatR;
using MovieFinder.Application.Models.Responses;

namespace MovieFinder.Application.Commands;

public class LoginCommand : IRequest<AuthResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
using MediatR;
using MovieFinder.Application.Models.Responses;

namespace MovieFinder.Application.Commands;

public class RegisterCommand : IRequest<AuthResponse>
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public RegisterCommand(string email, string username, string password)
    {
        Email = email;
        Username = username;
        Password = password;
    }
}
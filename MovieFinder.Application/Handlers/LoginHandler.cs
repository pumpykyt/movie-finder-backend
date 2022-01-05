using MediatR;
using MovieFinder.Application.Commands;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Application.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, AuthResponse>
{
    private readonly IAuthService _service;

    public LoginHandler(IAuthService service) => _service = service;

    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken) =>
        new AuthResponse { Token = await _service.LoginAsync(request.Email, request.Password) };
}
using MediatR;
using MovieFinder.Application.Commands;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Application.Handlers;

public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponse>
{
    private readonly IAuthService _service;

    public RegisterHandler(IAuthService service) => _service = service;

    public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken) =>
        new AuthResponse { Token = await _service.RegisterAsync(request.Email, request.Password, request.Username) };
}
using MediatR;
using MovieFinder.Application.Commands;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Application.Handlers;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, string>
{
    private readonly IRoleService _service;

    public CreateRoleHandler(IRoleService service)
    {
        _service = service;
    }

    public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken) =>
        await _service.CreateRoleAsync(request.Name);
}
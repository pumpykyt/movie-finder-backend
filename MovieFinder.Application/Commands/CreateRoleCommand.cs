using MediatR;

namespace MovieFinder.Application.Commands;

public class CreateRoleCommand : IRequest<string>
{
    public string Name { get; set; }

    public CreateRoleCommand(string name)
    {
        Name = name;
    }
}
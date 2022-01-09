using MediatR;
using MovieFinder.Application.Models.Responses;

namespace MovieFinder.Application.Commands;

public class DeleteMarkCommand : IRequest<double>, IRequest<DeleteMarkResponse>
{
    public DeleteMarkCommand(string markId)
    {
        MarkId = markId;
    }

    public string MarkId { get; set; }
}
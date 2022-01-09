using MediatR;
using MovieFinder.Application.Commands;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Application.Handlers;

public class DeleteMarkHandler : IRequestHandler<DeleteMarkCommand, DeleteMarkResponse>
{
    private readonly IMarkService _service;

    public DeleteMarkHandler(IMarkService service)
    {
        _service = service;
    }

    public async Task<DeleteMarkResponse> Handle(DeleteMarkCommand request, CancellationToken cancellationToken) =>
        new DeleteMarkResponse
        {
            MovieRating = await _service.DeleteMarkAsync(request.MarkId)
        };
}
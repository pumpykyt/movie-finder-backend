using MediatR;

namespace MovieFinder.Application.Models.Responses;

public class DeleteMarkResponse : IRequest<Unit>
{
    public double MovieRating { get; set; }
}
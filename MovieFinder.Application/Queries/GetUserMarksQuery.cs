using MediatR;
using MovieFinder.Application.Models.Responses;

namespace MovieFinder.Application.Queries;

public class GetUserMarksQuery : IRequest<List<MarkResponse>>
{
    public string UserId { get; set; }

    public GetUserMarksQuery(string userId)
    {
        UserId = userId;
    }
}
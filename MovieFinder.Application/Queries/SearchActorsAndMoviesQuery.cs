using MediatR;
using MovieFinder.Application.Models.Responses;

namespace MovieFinder.Application.Queries;

public class SearchActorsAndMoviesQuery : IRequest<SearchResultResponse>
{
    public SearchActorsAndMoviesQuery(string? searchQuery)
    {
        SearchQuery = searchQuery;
    }

    public string? SearchQuery { get; set; }
}
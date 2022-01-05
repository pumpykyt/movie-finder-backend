using MediatR;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Data.Entities;

namespace MovieFinder.Application.Queries;

public class GetMoviesQuery : IRequest<List<MovieResponse>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? SearchQuery { get; set; }
    public string? SortQuery { get; set; }
    
    public GetMoviesQuery(int pageSize, int pageNumber, string? searchQuery, string? sortQuery)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        SearchQuery = searchQuery;
        SortQuery = sortQuery;
    }
}
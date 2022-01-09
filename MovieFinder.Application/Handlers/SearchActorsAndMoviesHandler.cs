using AutoMapper;
using MediatR;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Application.Queries;
using MovieFinder.Domain.Interfaces;
using MovieFinder.Domain.Models;

namespace MovieFinder.Application.Handlers;

public class SearchActorsAndMoviesHandler : IRequestHandler<SearchActorsAndMoviesQuery, SearchResultResponse>
{
    private readonly ISearchService _service;
    private readonly IMapper _mapper;

    public SearchActorsAndMoviesHandler(IMapper mapper, ISearchService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<SearchResultResponse> Handle(SearchActorsAndMoviesQuery request,
        CancellationToken cancellationToken) =>
        _mapper.Map<SearchResultDomain, SearchResultResponse>(
            await _service.SearchActorsAndMoviesAsync(request.SearchQuery));
}
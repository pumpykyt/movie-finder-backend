using AutoMapper;
using MediatR;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Application.Queries;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Application.Handlers;

public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, List<MovieResponse>>
{
    private readonly IMovieService _service;
    private readonly IMapper _mapper;

    public GetMoviesHandler(IMovieService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<List<MovieResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<List<Movie>, List<MovieResponse>>(await _service.GetMoviesAsync(request.PageSize,
            request.PageNumber, request.SearchQuery, request.SortQuery));
}
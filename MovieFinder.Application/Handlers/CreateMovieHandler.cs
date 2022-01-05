using AutoMapper;
using MediatR;
using MovieFinder.Application.Commands;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Application.Handlers;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieResponse>
{
    private readonly IMovieService _service;
    private readonly IMapper _mapper;

    public CreateMovieHandler(IMovieService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken) =>
        _mapper.Map<Movie, MovieResponse>(await _service.CreateMovieAsync(request.Name, request.Description,
            request.Country, request.Budget, request.Director, request.Base64));
}
using AutoMapper;
using MediatR;
using MovieFinder.Application.Commands;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Application.Handlers;

public class CreateMarkHandler : IRequestHandler<CreateMarkCommand, MarkResponse>
{
    private readonly IMarkService _service;
    private readonly IMapper _mapper;

    public CreateMarkHandler(IMarkService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<MarkResponse> Handle(CreateMarkCommand request, CancellationToken cancellationToken) =>
        _mapper.Map<Mark, MarkResponse>(await _service.CreateMarkAsync(request.MovieId, request.UserId, request.Value));
}
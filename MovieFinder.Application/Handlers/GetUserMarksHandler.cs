using AutoMapper;
using MediatR;
using MovieFinder.Application.Models.Responses;
using MovieFinder.Application.Queries;
using MovieFinder.Data.Entities;
using MovieFinder.Domain.Interfaces;

namespace MovieFinder.Application.Handlers;

public class GetUserMarksHandler : IRequestHandler<GetUserMarksQuery, List<MarkResponse>>
{
    private readonly IMarkService _service;
    private readonly IMapper _mapper;

    public GetUserMarksHandler(IMarkService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<List<MarkResponse>> Handle(GetUserMarksQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<List<Mark>, List<MarkResponse>>(await _service.GetUserMarksAsync(request.UserId));
}
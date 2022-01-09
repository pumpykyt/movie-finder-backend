using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Application.Queries;

namespace MovieFinder.Web.Controllers;

public sealed class SearchController : ApiControllerBase
{
    public SearchController(ISender mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> SearchActorsAndMoviesAsync(string? searchQuery) =>
        Ok(await Mediator.Send(new SearchActorsAndMoviesQuery(searchQuery)));
}
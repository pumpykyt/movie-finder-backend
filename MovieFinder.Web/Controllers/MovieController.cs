using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Application.Commands;
using MovieFinder.Application.Models.Requests;
using MovieFinder.Application.Queries;

namespace MovieFinder.Web.Controllers;

public sealed class MovieController : ApiControllerBase
{
    public MovieController(ISender mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> CreateMovieAsync(MovieRequest model) => Ok(
        await Mediator.Send(new CreateMovieCommand(model.Name, model.Description, model.Country, model.Budget,
            model.Director, model.Base64)));

    [HttpGet]
    public async Task<IActionResult> GetMoviesAsync(int pageSize, int pageNumber, 
        string? searchQuery, string? sortQuery) => 
            Ok(await Mediator.Send(new GetMoviesQuery(pageSize, pageNumber, searchQuery, sortQuery)));
}
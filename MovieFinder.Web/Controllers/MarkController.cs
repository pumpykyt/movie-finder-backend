using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Application.Commands;
using MovieFinder.Application.Models.Requests;
using MovieFinder.Application.Queries;

namespace MovieFinder.Web.Controllers;

public sealed class MarkController : ApiControllerBase
{
    public MarkController(ISender mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetUserMarksAsync(string userId) =>
        Ok(await Mediator.Send(new GetUserMarksQuery(userId)));

    [HttpPost]
    public async Task<IActionResult> CreateMarkAsync(MarkRequest model) =>
        Ok(await Mediator.Send(new CreateMarkCommand(model.MovieId, model.UserId, model.Value)));

    [HttpDelete]
    public async Task<IActionResult> DeleteMarkAsync(string markId) =>
        Ok(await Mediator.Send(new DeleteMarkCommand(markId)));
}
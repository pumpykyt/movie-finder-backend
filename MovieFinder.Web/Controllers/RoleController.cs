using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Application.Commands;

namespace MovieFinder.Web.Controllers;

public sealed class RoleController : ApiControllerBase
{
    public RoleController(ISender mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> CreateRoleAsync(string name) =>
        Ok(await Mediator.Send(new CreateRoleCommand(name)));
}
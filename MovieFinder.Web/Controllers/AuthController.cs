using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Application.Commands;
using MovieFinder.Application.Models.Requests;

namespace MovieFinder.Web.Controllers;

public sealed class AuthController : ApiControllerBase
{
    public AuthController(ISender mediator) : base(mediator) { }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest model) => 
        Ok(await Mediator.Send(new LoginCommand(model.Email, model.Password)));

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest model) =>
        Ok(await Mediator.Send(new RegisterCommand(model.Email, model.Username, model.Password)));
}
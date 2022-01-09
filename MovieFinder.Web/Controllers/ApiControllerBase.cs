using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieFinder.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly ISender Mediator;

    protected ApiControllerBase(ISender mediator) => Mediator = mediator ?? throw new ArgumentNullException();
}
using System.Net;
using FutureComputer.Application.Users.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FutureComputer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> LoginUser(UserLoginCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
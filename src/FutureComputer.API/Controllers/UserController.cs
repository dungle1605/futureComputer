using System.Net;
using FutureComputer.Application.Users.LoginUser;
using FutureComputer.Application.Users.Register;
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

    [HttpPost("login")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<string>> LoginUser([FromBody] UserLoginCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> RegisterAccount([FromBody] UserRegisterCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
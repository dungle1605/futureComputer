using MediatR;

namespace FutureComputer.Application.Users.LoginUser;

public class UserLoginCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
using MediatR;

namespace FutureComputer.Application.Users.LoginUser;

public class UserLoginCommand : IRequest<string>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
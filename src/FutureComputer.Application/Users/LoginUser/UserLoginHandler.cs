using MediatR;

namespace FutureComputer.Application.Users.LoginUser;

public class UserLoginHandler : IRequestHandler<UserLoginCommand, string>
{
    public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var pass = "Test";
        var email = "Test@123";
        var roleId = 1;

        return "";
    }
}

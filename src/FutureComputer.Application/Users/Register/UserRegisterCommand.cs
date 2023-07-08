using MediatR;

namespace FutureComputer.Application.Users.Register
{
    public class UserRegisterCommand : IRequest<string>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

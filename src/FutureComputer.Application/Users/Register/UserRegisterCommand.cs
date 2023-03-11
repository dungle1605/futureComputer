using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Users.Register
{
    public class UserRegisterCommand : IRequest<string>
    {
        public string UserName { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

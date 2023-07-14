using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Users.Register;

public class GetUserByUsernameSpecifification : Specification<User>
{
    public GetUserByUsernameSpecifification(string username)
    {
        Query.Where(x => x.UserName.ToUpper() == username.ToUpper());
    }
}
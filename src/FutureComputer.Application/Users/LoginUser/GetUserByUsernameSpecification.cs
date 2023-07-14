using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Users.LoginUser
{
    public class GetUserByUsernameSpecification : Specification<User>
    {
        public GetUserByUsernameSpecification(string username)
        {
            Query.Where(x => x.UserName == username && x.IsActive);
        }
    }
}

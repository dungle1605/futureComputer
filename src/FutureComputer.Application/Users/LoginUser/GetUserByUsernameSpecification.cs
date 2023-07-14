using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Users.LoginUser
{
    public class GetUserByUsernameSpecification : Specification<User>
    {
        public GetUserByUsernameSpecification(string email)
        {
            Query.Where(x => x.Email == email && x.IsActive);
        }
    }
}

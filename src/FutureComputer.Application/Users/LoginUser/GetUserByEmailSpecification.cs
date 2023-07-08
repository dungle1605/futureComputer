using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Users.LoginUser
{
    public class GetUserByEmailSpecification : Specification<User>
    {
        public GetUserByEmailSpecification(string email)
        {
            Query.Where(x => x.Email == email && x.IsActive);
        }
    }
}

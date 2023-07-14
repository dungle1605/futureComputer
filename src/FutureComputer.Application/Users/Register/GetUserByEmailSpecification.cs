using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Users.Register;

public class GetUserByEmailSpecification : Specification<User>
{
    public GetUserByEmailSpecification(string email)
    {
        Query.Where(x => x.Email.ToUpper() == email.ToUpper());
    }
}
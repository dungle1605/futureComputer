using Ardalis.Specification;
using FutureComputer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Users.LoginUser
{
    public class GetUserRoleSpecification : Specification<Role>
    {
        public GetUserRoleSpecification(Guid roleId) 
        {
            Query.Where(x => x.Id.Equals(roleId));
        }
    }
}

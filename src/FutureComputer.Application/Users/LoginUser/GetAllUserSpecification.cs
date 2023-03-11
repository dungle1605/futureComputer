using Ardalis.Specification;
using FutureComputer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Users.LoginUser
{
    public class GetAllUserSpecification : Specification<User>
    {
        public GetAllUserSpecification() 
        {
            Query.Where(x => x.IsActive);
        }
    }
}

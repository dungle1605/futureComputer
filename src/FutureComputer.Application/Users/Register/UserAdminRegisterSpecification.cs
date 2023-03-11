﻿using Ardalis.Specification;
using FutureComputer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Users.Register
{
    public class UserAdminRegisterSpecification : Specification<Role>
    {
        public UserAdminRegisterSpecification() 
        {
            Query.Where(x => x.RoleName == "Admin");
        }
    }
}

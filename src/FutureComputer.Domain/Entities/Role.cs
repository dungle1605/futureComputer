using FutureComputer.Domain.Common;
using FutureComputer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Domain.Entities
{
    public class Role : BaseAuditableEntity, IAggregateRoot
    {
        public string RoleName { get; set; }
        public IList<User> Users { get; set; }
    }
}

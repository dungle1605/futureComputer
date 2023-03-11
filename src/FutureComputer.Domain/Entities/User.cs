using FutureComputer.Domain.Common;
using FutureComputer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Domain.Entities
{
    public class User : BaseAuditableEntity, IAggregateRoot
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public bool IsActive { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}

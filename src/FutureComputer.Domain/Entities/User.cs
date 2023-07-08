using FutureComputer.Domain.Common;
using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Domain.Entities
{
    public class User : BaseAuditableEntity, IAggregateRoot
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
    }
}

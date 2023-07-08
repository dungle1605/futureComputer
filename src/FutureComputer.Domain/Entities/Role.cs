using FutureComputer.Domain.Common;

namespace FutureComputer.Domain.Entities
{
    public class Role : BaseAuditableEntity
    {
        public string RoleName { get; set; }
        public IList<User> Users { get; set; }
    }
}

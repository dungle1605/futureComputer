using FutureComputer.Domain.Common;
using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Domain.Entities;

public class Customer : BaseAuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAvailable { get; set; }
    public IList<Address> Addresses { get; set; }
}
using FutureComputer.Domain.Common;
using FutureComputer.Domain.Enum;
using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Domain.Entities;

public class Address : BaseAuditableEntity, IAggregateRoot
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string AddressNumber { get; set; }
    public Guid CustomerId { get; set; }
    public AddressType AddressType { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
}
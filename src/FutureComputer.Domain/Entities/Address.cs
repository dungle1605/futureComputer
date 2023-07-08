using FutureComputer.Domain.Common;
using FutureComputer.Domain.Enum;

namespace FutureComputer.Domain.Entities;

public class Address : BaseAuditableEntity
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
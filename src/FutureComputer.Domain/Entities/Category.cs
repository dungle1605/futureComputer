using FutureComputer.Domain.Common;
using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Domain.Entities;

public class Category : BaseAuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public bool IsAvailable { get; set; }

    public IList<Product> Products { get; set; }
}
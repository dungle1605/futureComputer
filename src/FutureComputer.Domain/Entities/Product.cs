using FutureComputer.Domain.Common;
using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Domain.Entities;

public class Product : BaseAuditableEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? ImageUrls { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}
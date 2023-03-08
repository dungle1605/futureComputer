using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Products.UpdateProduct;

public class UpdateProductSpecification : Specification<Product>
{
    public UpdateProductSpecification(Guid id)
    {
        Query.Where(p => p.Id.Equals(id)
                        && !p.IsDeleted);
    }
}
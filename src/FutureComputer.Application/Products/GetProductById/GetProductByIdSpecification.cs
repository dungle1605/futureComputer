using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Products.GetProductById;

public class GetProductByIdSpecification : Specification<Product>
{
    public GetProductByIdSpecification(Guid id)
    {
        Query.Where(p => p.Id.Equals(id)
                        && !p.IsDeleted);
    }
}
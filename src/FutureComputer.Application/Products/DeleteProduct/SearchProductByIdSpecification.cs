using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Products.DeleteProduct;

public class SearchProductByIdSpecification : Specification<Product>
{
    public SearchProductByIdSpecification(Guid id)
    {
        Query.Where(p => p.Id.Equals(id)
                        && !p.IsDeleted);
    }
}
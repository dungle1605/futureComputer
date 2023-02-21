using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Products.GetAllProducts;

public class GetAllProductsSpecification : Specification<Product>
{
    public GetAllProductsSpecification()
    {
        Query.Where(p => !p.IsDeleted);
    }
}
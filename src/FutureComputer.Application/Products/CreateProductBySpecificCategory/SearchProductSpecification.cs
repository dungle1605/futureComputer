using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Products.CreateProductBySpecificCategory;

public class SearchProductSpecification : Specification<Product>
{
    public SearchProductSpecification(string name)
    {
        Query.Where(x => x.Name.ToUpper() == name.Replace(" ", "").ToUpper() && !x.IsDeleted);
    }
}
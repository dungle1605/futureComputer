using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Products.GetProductBySearch;

public class GetProductBySearchSpecification : Specification<Product>
{
    public GetProductBySearchSpecification(float price, string categoryName, string name)
    {
        if (price != 0 && !string.IsNullOrWhiteSpace(categoryName) && !string.IsNullOrWhiteSpace(name))
        {
            Query.Where(x => x.Price.Equals(price)
                            && !x.IsDeleted)
                    .Include(x => x.Category)
                    .Search(x => x.Category.Name, categoryName)
                    .Search(x => x.Name, name);
        }
        else if (price != 0 && !string.IsNullOrWhiteSpace(categoryName) && string.IsNullOrWhiteSpace(name))
        {
            Query.Where(x => x.Price.Equals(price)
                            && !x.IsDeleted)
                    .Include(x => x.Category)
                    .Search(x => x.Category.Name, categoryName);
        }
        else if (price != 0 && string.IsNullOrWhiteSpace(categoryName) && !string.IsNullOrWhiteSpace(name))
        {
            Query.Where(x => x.Price.Equals(price)
                            && !x.IsDeleted)
                    .Include(x => x.Category)
                    .Search(x => x.Name, name);
        }
        else if (price != 0)
        {
            Query.Where(x => x.Equals(price)
                            && !x.IsDeleted);
        }
        else
        {
            Query.Where(x => !x.IsDeleted);
        }
    }
}
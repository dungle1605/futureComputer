using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Categories.CategoriesOfTheMonth;

public class GetCategoriesOfTheMonthSpecification : Specification<Category>
{
    public GetCategoriesOfTheMonthSpecification()
    {
        Query.Where(x => x.IsAvailable)
            .Include(x => x.Products)
            .Take(3);
    }
}
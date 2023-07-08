using Ardalis.Specification;
using FutureComputer.Domain.Entities;

namespace FutureComputer.Application.Categories.CreateCategory
{
    public class CreateCategorySpecification : Specification<Category>
    {
        public CreateCategorySpecification(string name)
        {
            Query.Where(x => x.Name.ToUpper() == name.ToUpper());
        }
    }
}

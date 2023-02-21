using Ardalis.Specification;
using FutureComputer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.GetAllCategories
{
    public class GetAllCategoriesSpecification : Specification<Category>
    {
        public GetAllCategoriesSpecification() 
        {
            Query.Where(p => p.IsAvailable);
        }
    }
}

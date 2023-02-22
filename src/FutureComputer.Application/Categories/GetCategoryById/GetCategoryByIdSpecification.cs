using Ardalis.Specification;
using FutureComputer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.GetCategoryById
{
    public class GetCategoryByIdSpecification : Specification<Category>
    {
        public GetCategoryByIdSpecification(Guid id) 
        {
            Query.Where(c => c.Id.Equals(id) 
                            && c.IsAvailable);
        }
    }
}

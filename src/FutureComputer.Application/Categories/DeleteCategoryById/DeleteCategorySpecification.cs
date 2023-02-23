using Ardalis.Specification;
using FutureComputer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.DeleteCategoryById
{
    public class DeleteCategorySpecification : Specification<Category>
    {
        public DeleteCategorySpecification(Guid id) 
        { 
            Query.Where(x => x.Id.Equals(id));
        }
    }
}

using Ardalis.Specification;
using FutureComputer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.CreateCategory
{
    public class CreateCategorySpecification : Specification<Category>
    {
        public CreateCategorySpecification(string name) 
        { 
            Query.Where(x => x.Name == name);
        }
    }
}

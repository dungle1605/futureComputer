using FutureComputer.Application.Categories.Common;
using FutureComputer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryResponse>
    {
        public string Name { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}

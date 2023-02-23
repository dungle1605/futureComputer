using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.DeleteCategoryById
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

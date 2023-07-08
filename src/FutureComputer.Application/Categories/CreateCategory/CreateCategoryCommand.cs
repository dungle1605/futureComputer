using FutureComputer.Application.Categories.Common;
using MediatR;

namespace FutureComputer.Application.Categories.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryResponse>
    {
        public string? Name { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}

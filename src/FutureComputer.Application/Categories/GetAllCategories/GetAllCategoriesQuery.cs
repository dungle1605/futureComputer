using FutureComputer.Application.Categories.Common;
using MediatR;

namespace FutureComputer.Application.Categories.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryResponse>>
    {
    }
}

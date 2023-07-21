using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
    {
        private readonly IRepository<Category> _repository;
        private readonly MappingProfile<Category, CategoryResponse> _mapper;

        public GetAllCategoriesQueryHandler(IRepository<Category> repository, MappingProfile<Category, CategoryResponse> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var filter = new GetAllCategoriesSpecification();
            var lstCategory = await _repository.ListAsync(filter, cancellationToken);

            var lstCategoryResponse = lstCategory.Select(p => _mapper.MapperHandler(p))
                                                .ToList();

            return lstCategoryResponse;
        }
    }
}

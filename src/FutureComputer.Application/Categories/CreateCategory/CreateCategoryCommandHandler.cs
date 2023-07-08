using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Categories.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly IRepository<Category> _repository;
        private readonly MappingProfile<Category, CategoryResponse> _mapperResponse;
        private readonly ICurrentUserService _currentUser;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IRepository<Category> repository, MappingProfile<Category, CategoryResponse> mapperResponse, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _repository = repository;
            _mapperResponse = mapperResponse;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var filter = new CreateCategorySpecification(request.Name);
            var isExisted = await _repository.AnyAsync(filter, cancellationToken);

            var categoryResponse = new CategoryResponse();
            if (!isExisted)
            {
                var currentUserId = _currentUser.Id;

                var newCategory = new Category
                {
                    Name = request.Name,
                    Created = DateTime.Now,
                    CreatedBy = currentUserId,
                    IsAvailable = true
                };
                var createdResult = await _repository.AddAsync(newCategory, cancellationToken);

                _unitOfWork.SaveChange(cancellationToken);
                categoryResponse = _mapperResponse.MapperHandler(createdResult);
            }

            return categoryResponse;
        }
    }
}

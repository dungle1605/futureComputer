using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;
        private readonly MappingProfile<UpdateCategoryCommand, Category> _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, MappingProfile<UpdateCategoryCommand, Category> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var filter = new UpdateCategorySpecification(request.Id);
            var isExisted = await _repository.AnyAsync(filter);
            if (isExisted)
            {
                var mapped = _mapper.MapperHandler(request);
                await _repository.UpdateAsync(mapped);
                await _repository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}

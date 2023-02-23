using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.DeleteCategoryById
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _repository;
        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var filter = new DeleteCategorySpecification(request.Id);
            var category = await _repository.FirstOrDefaultAsync(filter);
            if (category != null)
            {
                category.IsAvailable = false;
                await _repository.UpdateAsync(category);
                await _repository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}

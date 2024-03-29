﻿using FutureComputer.Application.Configs;
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

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var filter = new UpdateCategorySpecification(request.Id);
            var category = await _repository.FirstOrDefaultAsync(filter);
            if (category != null)
            {
                category.Name = request.Name ?? category.Name;
                await _repository.UpdateAsync(category);
                await _repository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}

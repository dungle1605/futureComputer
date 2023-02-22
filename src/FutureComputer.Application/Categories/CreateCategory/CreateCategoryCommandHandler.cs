using AutoMapper;
using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly IRepository<Category> _repository;
        private readonly MappingProfile<CreateCategoryCommand, Category> _mapper;
        private readonly MappingProfile<Category, CategoryResponse> _mapperResponse;
        private readonly IUnitOfWork _unitOfWork; 

        public CreateCategoryCommandHandler(IRepository<Category> repository, MappingProfile<CreateCategoryCommand, Category> mappper, 
            MappingProfile<Category, CategoryResponse> mapperResponse, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mappper;
            _mapperResponse = mapperResponse;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var filter = new CreateCategorySpecification(request.Name);
            var isExisted = await _repository.AnyAsync(filter);

            var categoryResponse = new CategoryResponse();
            if (!isExisted)
            {
                var mapped = _mapper.MapperHandler(request);
                var createdResult = await _repository.AddAsync(mapped);
                await _repository.SaveChangesAsync();
                categoryResponse = _mapperResponse.MapperHandler(createdResult);
            }

            return categoryResponse;
        }
    }
}

using AutoMapper;
using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
    {
        private readonly IRepository<Category> _repository;
        private readonly MappingProfile<Category, CategoryResponse> _mapper;
        public GetCategoryByIdHandler(IRepository<Category> repository, MappingProfile<Category, CategoryResponse> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var filter = new GetCategoryByIdSpecification(request.Id);
            var category = await _repository.FirstOrDefaultAsync(filter);

            return _mapper.MapperHandler(category);
        }
    }
}

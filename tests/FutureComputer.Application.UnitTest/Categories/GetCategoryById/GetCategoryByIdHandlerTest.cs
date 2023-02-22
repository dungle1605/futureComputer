using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Categories.GetCategoryById;
using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.UnitTest.Categories.GetCategoryById
{
    public class GetCategoryByIdHandlerTest
    {
        private readonly Mock<IRepository<Category>> _repository;
        private readonly Mock<MappingProfile<Category, CategoryResponse>> _mapper;

        private readonly GetCategoryByIdHandler _handler;

        public GetCategoryByIdHandlerTest() 
        { 
            _repository = new Mock<IRepository<Category>>();
            _mapper = new Mock<MappingProfile<Category, CategoryResponse>>();

            _handler = new GetCategoryByIdHandler(_repository.Object, _mapper.Object);
        }
    }
}

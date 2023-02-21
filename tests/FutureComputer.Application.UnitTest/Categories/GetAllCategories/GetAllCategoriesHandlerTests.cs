using Ardalis.Specification;
using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Categories.GetAllCategories;
using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FutureComputer.Application.UnitTest.Categories.GetAllCategories
{
    public class GetAllCategoriesHandlerTests
    {
        private readonly GetAllCategoriesQueryHandler _handler;
        private readonly Mock<IRepository<Category>> _repository;
        private readonly Mock<MappingProfile<Category, CategoryResponse>> _mapper;
        
        public GetAllCategoriesHandlerTests() 
        { 
            _repository = new Mock<IRepository<Category>>();
            _mapper = new Mock<MappingProfile<Category, CategoryResponse>>();
            _handler = new GetAllCategoriesQueryHandler(_repository.Object, _mapper.Object);
        }

        [Fact]
        public async void GetAllCategories_EmptyList_ReturnEmptyList()
        {
            var query = new GetAllCategoriesQuery();

            _repository.Setup(r => r.ListAsync(It.IsAny<ISpecification<Category>>(), default))
                        .Returns(Task.FromResult(new List<Category>()));

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.Empty(result);
        }

        [Fact]
        public async void GetAllCategories_ListHasItem_ReturnListItem()
        {
            var query = new GetAllCategoriesQuery();

            _repository.Setup(r => r.ListAsync(It.IsAny<ISpecification<Category>>(), default))
                        .Returns(Task.FromResult(new List<Category> {
                            new Category
                            {
                                Id = Guid.NewGuid(),
                                Name = "Test1",
                            },
                            new Category
                            {
                                Id = Guid.NewGuid(),
                                Name = "Test2",
                            }
                        }));

            var result = await _handler.Handle(query, default);
            
            Assert.Equal(2, result.Count());
            Assert.Equal("Test1", result[0].Name);
        }
    }
}

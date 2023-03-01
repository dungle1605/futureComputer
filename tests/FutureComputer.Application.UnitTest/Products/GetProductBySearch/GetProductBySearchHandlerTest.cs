using Ardalis.Specification;
using FutureComputer.Application.Configs;
using FutureComputer.Application.Products.Common;
using FutureComputer.Application.Products.GetProductBySearch;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using Moq;
using Xunit;

namespace FutureComputer.Application.UnitTest.Products.GetProductBySearch;

public class GetProductBySearchHandlerTest
{
    private readonly Mock<IRepository<Product>> _repository;
    private readonly Mock<MappingProfile<Product, ProductResponse>> _mapper;
    private readonly GetProductBySearchHandler _handler;

    public GetProductBySearchHandlerTest()
    {
        _repository = new Mock<IRepository<Product>>();
        _mapper = new Mock<MappingProfile<Product, ProductResponse>>();
        _handler = new GetProductBySearchHandler(_repository.Object, _mapper.Object);
    }

    [Fact]
    public async void GetProductBySearch_EmptySearchField_ReturnListResponse()
    {
        var query = new SearchProductQuery(-3, "", string.Empty);

        var lstProd = new List<Product>{
            new Product{
                Price = 1,
                Name = "Test Prod1",
                Category = new Category()
            },
         };
        _repository.Setup(x => x.ListAsync(It.IsAny<ISpecification<Product>>(), default)).Returns(Task.FromResult(lstProd));

        var result = await _handler.Handle(query, default);

        Assert.Single(result);
    }

    [Fact]
    public async void GetProductBySearch_ValidSearchField_ReturnListResponse()
    {
        var query = new SearchProductQuery(1, "", "Test Prod1");

        var lstProd = new List<Product>{
            new Product{
                Price = 1,
                Name = "Test Prod1",
                Category = new Category()
            },
         };
        _repository.Setup(x => x.ListAsync(It.IsAny<ISpecification<Product>>(), default)).Returns(Task.FromResult(lstProd));

        var result = await _handler.Handle(query, default);

        Assert.Single(result);
    }

    private List<Product> DummyList()
    {
        var cate1 = new Category { Name = "Test Cate1" };
        var cate2 = new Category { Name = "Test Cate2" };
        var lstProd = new List<Product>{
            new Product{
                Price = 1,
                Name = "Test Prod1",
                Category = cate1
            },
            new Product{
                Price = 2,
                Name = "Test Prod2",
                Category = cate2
            },
            new Product{
                Price = 3,
                Name = "Test Prod3",
                Category = cate1
            },
            new Product{
                Price = 4,
                Name = "Test Prod4",
                Category = cate2
            },
            new Product{
                Price = 5,
                Name = "Test Prod5",
                Category = cate2
            },
        };

        return lstProd;
    }
}
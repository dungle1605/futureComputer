using Ardalis.Specification;
using FutureComputer.Application.Configs;
using FutureComputer.Application.Products.Common;
using FutureComputer.Application.Products.GetAllProducts;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using Moq;
using Xunit;

namespace FutureComputer.Application.UnitTest.Products.GetAllProducts;

public class GetAllProductsHandlerTests
{
    private readonly GetAllProductsQueryHandler _handler;
    private readonly Mock<IRepository<Product>> _repository;
    private readonly Mock<MappingProfile<Product, ProductResponse>> _mapper;

    public GetAllProductsHandlerTests()
    {
        _repository = new Mock<IRepository<Product>>();
        _mapper = new Mock<MappingProfile<Product, ProductResponse>>();
        _handler = new GetAllProductsQueryHandler(_repository.Object, _mapper.Object);
    }

    [Fact]
    public async void GetAllProducts_EmptyList_ReturnEmptyList()
    {
        var query = new GetAllProductsQuery();

        _repository.Setup(r => r.ListAsync(It.IsAny<ISpecification<Product>>(), default))
                    .Returns(Task.FromResult(new List<Product>()));

        var result = await _handler.Handle(query, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async void GetAllProducts_ListHasItem_ReturnListItem()
    {
        var query = new GetAllProductsQuery();

        _repository.Setup(r => r.ListAsync(It.IsAny<ISpecification<Product>>(), default))
                    .Returns(Task.FromResult(new List<Product>{
                        new Product{
                            Id = Guid.NewGuid(),
                            Name = "Test1"
                        },
                        new Product {
                            Id = Guid.NewGuid(),
                            Name = "Test2"
                        }
                    }));

        var result = await _handler.Handle(query, default);

        Assert.Equal(2, result.Count);
        Assert.Equal("Test1", result[0].Name);
    }
}
using Ardalis.Specification;
using FutureComputer.Application.Products.UpdateProduct;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using Moq;
using Xunit;

namespace FutureComputer.Application.UnitTest.Products.UpdateProduct;

public class UpdateProductHandlerTest
{
    private readonly Mock<IRepository<Product>> _repository;
    private readonly UpdateProductHandler _handler;

    public UpdateProductHandlerTest()
    {
        _repository = new Mock<IRepository<Product>>();
        _handler = new UpdateProductHandler(_repository.Object);
    }

    [Fact]
    public async void UpdateProduct_NotExistedProduct_ReturnFalse()
    {
        var command = new UpdateProductCommand();
        _repository.Setup(r => r.AnyAsync(It.IsAny<ISpecification<Product>>(), default)).Returns(Task.FromResult(false));

        var result = await _handler.Handle(command, default);

        Assert.False(result);
    }
}
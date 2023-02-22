using FutureComputer.Application.Configs;
using FutureComputer.Application.Products.Common;
using FutureComputer.Application.Products.GetProductById;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using Moq;

namespace FutureComputer.Application.UnitTest.Products.GetProductById;

public class GetProductByIdHandlerTest
{
    private readonly Mock<IRepository<Product>> _repository;
    private readonly Mock<MappingProfile<Product, ProductResponse>> _mapper;

    private readonly GetProductByIdHandler _handler;

    public GetProductByIdHandlerTest()
    {
        _repository = new Mock<IRepository<Product>>();
        _mapper = new Mock<MappingProfile<Product, ProductResponse>>();

        _handler = new GetProductByIdHandler(_repository.Object, _mapper.Object);
    }
}
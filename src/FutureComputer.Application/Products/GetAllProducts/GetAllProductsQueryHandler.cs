using FutureComputer.Application.Configs;
using FutureComputer.Application.Products.Common;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Products.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IRepository<Product> _repository;
    private readonly MappingProfile<Product, ProductResponse> _mapper;

    public GetAllProductsQueryHandler(IRepository<Product> repository, MappingProfile<Product, ProductResponse> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var filter = new GetAllProductsSpecification();
        var lstProduct = await _repository.ListAsync(filter);

        var lstProductResponse = lstProduct.Select(p => _mapper.MapperHandler(p))
                                            .ToList();

        return lstProductResponse;
    }
}

using FutureComputer.Application.Configs;
using FutureComputer.Application.Products.Common;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Products.GetProductBySearch;

public class GetProductBySearchHandler : IRequestHandler<SearchProductQuery, List<ProductResponse>>
{
    private readonly IRepository<Product> _repository;
    private readonly MappingProfile<Product, ProductResponse> _mapper;

    public GetProductBySearchHandler(IRepository<Product> repository, MappingProfile<Product, ProductResponse> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
    {
        var filter = new GetProductBySearchSpecification(request.Price, request.CategoryName, request.Name);
        var lstProductResponse = (await _repository.ListAsync(filter))
                                            .Select(p => _mapper.MapperHandler(p));

        return lstProductResponse.ToList();
    }
}

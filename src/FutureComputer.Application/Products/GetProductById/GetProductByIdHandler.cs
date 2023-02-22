using FutureComputer.Application.Configs;
using FutureComputer.Application.Products.Common;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Products.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IRepository<Product> _repository;
    private readonly MappingProfile<Product, ProductResponse> _mapper;

    public GetProductByIdHandler(IRepository<Product> repository, MappingProfile<Product, ProductResponse> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var filter = new GetProductByIdSpecification(request.Id);
        var product = await _repository.FirstOrDefaultAsync(filter);

        return _mapper.MapperHandler(product);
    }
}

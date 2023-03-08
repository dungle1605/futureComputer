using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Products.CreateProductBySpecificCategory;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, string>
{
    private readonly IRepository<Product> _repository;
    private readonly MappingProfile<CreateProductCommand, Product> _mapper;
    public CreateProductHandler(IRepository<Product> repository,
    MappingProfile<CreateProductCommand, Product> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var filter = new SearchProductSpecification(request.Name);
        var isExistedProduct = await _repository.AnyAsync(filter);
        if (isExistedProduct)
        {
            return "Product name is already existed in this system!";
        }
        try
        {
            var product = _mapper.MapperHandler(request);
            product.ImageUrls = "";
            await _repository.AddAsync(product);

            return "Add product successfully";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}

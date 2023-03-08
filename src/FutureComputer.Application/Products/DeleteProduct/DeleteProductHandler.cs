using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Products.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IRepository<Product> _repository;
    public DeleteProductHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var filter = new SearchProductByIdSpecification(request.Id);
        var isExistedProduct = await _repository.AnyAsync(filter);
        if (isExistedProduct)
        {
            var product = await _repository.FirstOrDefaultAsync(filter);
            product.IsDeleted = true;
            await _repository.UpdateAsync(product);

            return true;
        }
        return false;
    }
}
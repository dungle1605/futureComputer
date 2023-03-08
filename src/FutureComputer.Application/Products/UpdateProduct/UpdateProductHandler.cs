using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IRepository<Product> _repository;
    public UpdateProductHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var filter = new UpdateProductSpecification(request.Id);
        var isExistedProduct = await _repository.AnyAsync(filter);

        if (isExistedProduct)
        {
            var product = await _repository.FirstOrDefaultAsync(filter);
            UpdateProdHandling(request, product);
            await _repository.UpdateAsync(product);

            return true;
        }

        return false;
    }

    private void UpdateProdHandling(UpdateProductCommand newProd, Product oldProduct)
    {
        oldProduct.CategoryId = newProd.CategoryId;
        oldProduct.LastModified = DateTime.Now;
        oldProduct.Name = newProd.Name;
        oldProduct.Price = newProd.Price;
        oldProduct.Quantity = newProd.Quantity;
        oldProduct.Description = newProd.Description;
        oldProduct.ImageUrls = newProd.ImageFile.FileName;
    }
}

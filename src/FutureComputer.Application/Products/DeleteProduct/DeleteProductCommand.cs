using MediatR;

namespace FutureComputer.Application.Products.DeleteProduct;

public class DeleteProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
using FutureComputer.Application.Products.Common;
using MediatR;

namespace FutureComputer.Application.Products.GetProductById;

public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public Guid Id { get; set; }

    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
}
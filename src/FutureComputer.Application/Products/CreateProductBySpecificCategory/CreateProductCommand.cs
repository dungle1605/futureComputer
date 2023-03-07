using MediatR;
using Microsoft.AspNetCore.Http;

namespace FutureComputer.Application.Products.CreateProductBySpecificCategory;

public class CreateProductCommand : IRequest<bool>
{
    public float Price { get; set; }

    public Guid CategoryId { get; set; }

    public int Quantity { get; set; }

    public string Description { get; set; }

    public string Name { get; set; }

    public IFormFile ImageFile { get; set; }
}
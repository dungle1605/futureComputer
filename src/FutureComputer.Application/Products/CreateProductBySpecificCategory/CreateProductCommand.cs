using MediatR;
using Microsoft.AspNetCore.Http;

namespace FutureComputer.Application.Products.CreateProductBySpecificCategory;

public class CreateProductCommand : IRequest<bool>
{
    public int Price { get; set; }

    public Guid CategoryId { get; set; }

    public string Name { get; set; }

    public IFormFile ImageFile { get; set; }
}
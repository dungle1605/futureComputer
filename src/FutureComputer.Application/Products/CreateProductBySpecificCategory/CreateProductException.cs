using FutureComputer.Domain;

namespace FutureComputer.Application.Products.CreateProductBySpecificCategory;

public class CreateProductException : BusinessValidationException
{
    public CreateProductException(string message) : base(message)
    {

    }
}
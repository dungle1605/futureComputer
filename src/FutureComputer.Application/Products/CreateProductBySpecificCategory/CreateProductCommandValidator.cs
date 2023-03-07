using FluentValidation;
using FutureComputer.Application.Categories.Common;

namespace FutureComputer.Application.Products.CreateProductBySpecificCategory;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x)
            .Must(ValidateCommand)
            .WithMessage(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "Create Product"));
    }

    private bool ValidateCommand(CreateProductCommand command)
    {
        return command.ImageFile != null
            && command.Price > 0
            && command.Quantity > 0
            && !string.IsNullOrWhiteSpace(command.Name);
    }
}
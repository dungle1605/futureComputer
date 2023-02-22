using FluentValidation;
using FutureComputer.Application.Products.Common;

namespace FutureComputer.Application.Products.GetProductById;

public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
{
    [Obsolete]
    public GetProductByIdValidator()
    {
        RuleFor(x => x.Id)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "GetProductById"));
    }
}
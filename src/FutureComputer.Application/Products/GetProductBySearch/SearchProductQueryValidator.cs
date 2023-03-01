using FluentValidation;
using FutureComputer.Application.Categories.Common;

namespace FutureComputer.Application.Products.GetProductBySearch;

public class SearchProductQueryValidator : AbstractValidator<SearchProductQuery>
{
    public SearchProductQueryValidator()
    {
        RuleFor(x => x)
            .Must(ValidQuery)
            .WithMessage(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, nameof(SearchProductQuery)));
    }

    private bool ValidQuery(SearchProductQuery query)
    {
        return query.Price >= 0;
    }
}
using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Products.GetProductBySearch;
using Shouldly;
using Xunit;

namespace FutureComputer.Application.UnitTest.Products.GetProductBySearch;

public class SearchProductQueryValidatorTest
{
    [Fact]
    public void SearchProductQuery_InValidQuery_ShouldBeFalse()
    {
        var query = new SearchProductQuery(-3, "Test Cate", "Test Name");

        var result = new SearchProductQueryValidator().Validate(query);

        result.IsValid.ShouldBeFalse();
        result.Errors.First().Equals(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, nameof(SearchProductQuery)));
    }

    [Fact]
    public void SearchProductQuery_ValidQuery_ShouldBeTrue()
    {
        var query = new SearchProductQuery(2, "Test Cate", "Test Name");

        var result = new SearchProductQueryValidator().Validate(query);

        result.IsValid.ShouldBeTrue();
    }
}
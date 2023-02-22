using FutureComputer.Application.Products.Common;
using FutureComputer.Application.Products.GetProductById;
using Shouldly;
using Xunit;

namespace FutureComputer.Application.UnitTest.Products.GetProductById;

public class GetProductByIdValidatorTest
{
    [Fact]
    [Obsolete]
    public void GetProductValidator_EmptyQueryParam_ReturnFalse()
    {
        var query = new GetProductByIdQuery(Guid.Empty);

        var result = new GetProductByIdValidator().Validate(query);

        result.IsValid.ShouldBeFalse();
        result.Errors.First().Equals(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "GetProductById"));
    }

    [Fact]
    [Obsolete]
    public void GetProductValidator_ValidQuery_ReturnFalse()
    {
        var query = new GetProductByIdQuery(Guid.NewGuid());

        var result = new GetProductByIdValidator().Validate(query);

        result.IsValid.ShouldBeTrue();
    }
}
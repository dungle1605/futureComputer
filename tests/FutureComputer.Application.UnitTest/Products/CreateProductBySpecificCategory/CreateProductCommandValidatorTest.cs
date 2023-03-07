using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Products.CreateProductBySpecificCategory;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using Xunit;

namespace FutureComputer.Application.UnitTest.Products.CreateProductBySpecificCategory;

public class CreateProductCommandValidatorTest
{
    private readonly Mock<IFormFile> _imageFile;

    public CreateProductCommandValidatorTest()
    {
        _imageFile = new Mock<IFormFile>();
    }
    [Fact]
    public void CreateProductCommand_InValidCommand_ShouldBeFalse()
    {
        var commandMissingImage = new CreateProductCommand
        {
            ImageFile = null,
            Name = "Test",
            Price = 1,
            Quantity = 1
        };

        var commandMissingName = new CreateProductCommand
        {
            ImageFile = _imageFile.Object,
            Name = string.Empty,
            Price = 1,
            Quantity = 1
        };

        var commandWrongPrice = new CreateProductCommand
        {
            ImageFile = _imageFile.Object,
            Name = "Test",
            Price = -5,
            Quantity = 1
        };

        var commandWrongQuantity = new CreateProductCommand
        {
            ImageFile = _imageFile.Object,
            Name = "Test",
            Price = 1,
            Quantity = -5
        };

        var result1 = new CreateProductCommandValidator().Validate(commandMissingImage);
        var result2 = new CreateProductCommandValidator().Validate(commandMissingName);
        var result3 = new CreateProductCommandValidator().Validate(commandWrongPrice);
        var result4 = new CreateProductCommandValidator().Validate(commandWrongQuantity);

        result1.IsValid.ShouldBeFalse();
        result2.IsValid.ShouldBeFalse();
        result3.IsValid.ShouldBeFalse();
        result4.IsValid.ShouldBeFalse();

        result1.Errors.First().Equals(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "Create Product"));
        result2.Errors.First().Equals(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "Create Product"));
        result3.Errors.First().Equals(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "Create Product"));
        result4.Errors.First().Equals(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "Create Product"));
    }

    [Fact]
    public void CreateProductCommand_ValidCommand_ShouldBeTrue()
    {
        var command = new CreateProductCommand
        {
            ImageFile = _imageFile.Object,
            Name = "Test",
            Price = 1,
            Quantity = 1
        };

        var result = new CreateProductCommandValidator().Validate(command);

        result.IsValid.ShouldBeTrue();
    }
}
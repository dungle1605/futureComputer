using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Categories.GetCategoryById;
using FutureComputer.Application.Products.GetProductById;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FutureComputer.Application.UnitTest.Categories.GetCategoryById
{
    public class GetCategoryByIdValidatorTest
    {
        [Fact]
        [Obsolete]
        public void GetCategoryValidator_EmptyQueryParam_ReturnFalse() 
        {
            var query = new GetCategoryByIdQuery(Guid.Empty);

            var result = new GetCategoryByIdValidator().Validate(query);

            result.IsValid.ShouldBeFalse();
            result.Errors.First().Equals(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "GetCategoryById"));
        }

        [Fact]
        [Obsolete]
        public void GetCategoryValidator_ValidQuery_ReturnFalse()
        {
            var query = new GetCategoryByIdQuery(Guid.NewGuid());

            var result = new GetCategoryByIdValidator().Validate(query);

            result.IsValid.ShouldBeFalse();
        }
    }
}

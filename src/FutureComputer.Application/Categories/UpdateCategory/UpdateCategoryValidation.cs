using FluentValidation;
using FutureComputer.Application.Categories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Categories.UpdateCategory
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryCommand>
    {
        [Obsolete]
        public UpdateCategoryValidation()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "UpdateCategory"));

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(CommonConstant.ERROR_REQUEST_MESSAGE, "UpdateCategory"));
        }
    }
}

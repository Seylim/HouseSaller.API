using Core.Utilities.Messages;
using Entities.Dtos.Requests.CategoryDtos;
using FluentValidation;

namespace WebAPI.Validation.Category
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryRequest>
    {
        public AddCategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().NotNull().WithMessage(Messages.CategoryNameNotNull);
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage(Messages.CategoryNameLength);
        }
    }
}

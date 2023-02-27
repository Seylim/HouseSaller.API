using Core.Utilities.Messages;
using Entities.Dtos.Requests.CategoryDtos;
using FluentValidation;

namespace WebAPI.Validation.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull().WithMessage(Messages.CategoryIdNotNull);
            RuleFor(c => c.CategoryName).NotEmpty().NotNull().WithMessage(Messages.CategoryNameNotNull);
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage(Messages.CategoryNameLength);
            RuleFor(c => c.IsActive).NotEmpty().NotNull().WithMessage(Messages.CategoryIsActiveNotNull);
        }
    }
}

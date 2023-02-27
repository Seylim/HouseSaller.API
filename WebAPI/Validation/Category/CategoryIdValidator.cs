using Core.Utilities.Messages;
using Entities.Dtos.Requests.CategoryDtos;
using FluentValidation;

namespace WebAPI.Validation.Category
{
    public class CategoryIdValidator : AbstractValidator<CategoryIdRequest>
    {
        public CategoryIdValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull().WithMessage(Messages.CategoryIdNotNull);
        }
    }
}

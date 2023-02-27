using Core.Utilities.Messages;
using Entities.Dtos.Requests.CityDtos;
using FluentValidation;

namespace WebAPI.Validation.City
{
    public class CityNameValidator : AbstractValidator<CityNameRequest>
    {
        public CityNameValidator()
        {
            RuleFor(cty => cty.Name).NotEmpty().NotNull().WithMessage(Messages.CityNameNotNull);
            RuleFor(cty => cty.Name).MaximumLength(20).WithMessage(Messages.CityNameLength);
        }
    }
}

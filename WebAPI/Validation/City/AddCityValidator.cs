using Core.Utilities.Messages;
using Entities.Dtos.Requests.CityDtos;
using FluentValidation;

namespace WebAPI.Validation.City
{
    public class AddCityValidator : AbstractValidator<AddCityRequest>
    {
        public AddCityValidator()
        {
            RuleFor(cty => cty.Name).NotEmpty().NotNull().WithMessage(Messages.CityNameNotNull);
            RuleFor(cty => cty.Name).MaximumLength(20).WithMessage(Messages.CityNameLength);
            RuleFor(cty => cty.NumberPlate).NotEmpty().NotNull().WithMessage(Messages.CityNumberPlateNotNull);
            RuleFor(cty => cty.TelephoneCode).NotEmpty().NotNull().WithMessage(Messages.CityTelephoneCodeNotNull);
        }
    }
}

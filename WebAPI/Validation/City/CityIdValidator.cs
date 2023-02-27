using Core.Utilities.Messages;
using Entities.Dtos.Requests.CityDtos;
using FluentValidation;

namespace WebAPI.Validation.City
{
    public class CityIdValidator : AbstractValidator<CityIdRequest>
    {
        public CityIdValidator()
        {
            RuleFor(cty => cty.Id).NotEmpty().NotNull().WithMessage(Messages.CityIdNotNull);
        }
    }
}

using Core.Utilities.Messages;
using Entities.Dtos.Requests.DistrictDtos;
using FluentValidation;

namespace WebAPI.Validation.District
{
    public class AddDistrictValidator : AbstractValidator<AddDistrictRequest>
    {
        public AddDistrictValidator()
        {
            RuleFor(d => d.CityId).NotEmpty().NotNull().WithMessage(Messages.CityIdNotNull);
            RuleFor(d => d.Name).NotEmpty().NotNull().WithMessage(Messages.DistrictNameNotNull);
        }
    }
}

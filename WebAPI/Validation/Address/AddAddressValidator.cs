using Core.Utilities.Messages;
using Entities.Dtos.Requests.AddressDtos;
using FluentValidation;

namespace WebAPI.Validation.Address
{
    public class AddAddressValidator : AbstractValidator<AddAddressRequest>
    {
        public AddAddressValidator()
        {
            RuleFor(a => a.CityId).NotNull().NotEmpty().WithMessage(Messages.CityIdNotNull);
            RuleFor(a => a.SubDistrictId).NotNull().NotEmpty().WithMessage(Messages.SubDistrictIdNotNull);
            RuleFor(a => a.Details).NotNull().NotEmpty().WithMessage(Messages.AddressDetailsNotNull);
            RuleFor(a => a.Details).MaximumLength(250).WithMessage(Messages.AddressDetailsLength);
        }
    }
}

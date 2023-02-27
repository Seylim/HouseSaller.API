using Core.Utilities.Messages;
using Entities.Dtos.Requests.AddressDtos;
using FluentValidation;

namespace WebAPI.Validation.Address
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
    {
        public UpdateAddressValidator()
        {
            RuleFor(a => a.Id).NotEmpty().NotNull().WithMessage(Messages.AddressIdNotNull);
            RuleFor(a => a.CityId).NotEmpty().NotNull().WithMessage(Messages.CityIdNotNull);
            RuleFor(a => a.SubDistrictId).NotEmpty().NotNull().WithMessage(Messages.SubDistrictIdNotNull);
            RuleFor(a => a.Details).NotEmpty().NotNull().WithMessage(Messages.AddressDetailsNotNull);
            RuleFor(a => a.Details).MaximumLength(250).WithMessage(Messages.AddressDetailsLength);
            RuleFor(a => a.IsActive).NotEmpty().NotNull().WithMessage(Messages.AddressIsActiveNotNull);
        }
    }
}

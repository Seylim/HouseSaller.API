using Core.Utilities.Messages;
using Entities.Dtos.Requests.AddressDtos;
using FluentValidation;

namespace WebAPI.Validation.Address
{
    public class AddressIdValidator : AbstractValidator<AddressIdRequest>
    {
        public AddressIdValidator()
        {
            RuleFor(a => a.Id).NotNull().NotEmpty().WithMessage(Messages.AddressIdNotNull);
        }
    }
}

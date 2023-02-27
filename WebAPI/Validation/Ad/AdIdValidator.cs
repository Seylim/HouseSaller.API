using Core.Utilities.Messages;
using Entities.Dtos.Requests.AdDtos;
using FluentValidation;

namespace WebAPI.Validation.Ad
{
    public class AdIdValidator : AbstractValidator<AdIdRequest>
    {
        public AdIdValidator()
        {
            RuleFor(ad => ad.Id).NotEmpty().NotNull().WithMessage(Messages.AdIdNotNull);
        }
    }
}

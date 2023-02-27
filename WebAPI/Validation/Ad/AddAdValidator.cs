using Core.Utilities.Messages;
using Entities.Dtos.Requests.AdDtos;
using FluentValidation;

namespace WebAPI.Validation.Ad
{
    public class AddAdValidator : AbstractValidator<AddAdRequest>
    {
        public AddAdValidator()
        {
            RuleFor(ad => ad.CategoryId).NotEmpty().NotNull().WithMessage(Messages.CategoryIdNotNull);
            RuleFor(ad => ad.AddressId).NotEmpty().NotNull().WithMessage(Messages.AddressIdNotNull);
            RuleFor(ad => ad.UserId).NotEmpty().NotNull().WithMessage(Messages.UserIdNotNull);
            RuleFor(ad => ad.Title).NotNull().NotEmpty().WithMessage(Messages.AdTitleNotNull);
            RuleFor(ad => ad.Title).MaximumLength(50).WithMessage(Messages.AdTitleLength);
            RuleFor(ad => ad.Description).NotNull().NotEmpty().WithMessage(Messages.AdDescriptionNotNull);
            RuleFor(ad => ad.Description).MaximumLength(250).WithMessage(Messages.AdDescriptionLength);
            RuleFor(ad => ad.Price).NotNull().NotEmpty().WithMessage(Messages.AdPriceNotNull);
        }
    }
}

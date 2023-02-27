using Core.Utilities.Messages;
using Entities.Dtos.Requests.Photo;
using FluentValidation;

namespace WebAPI.Validation.Photo
{
    public class PhotoIdValidator : AbstractValidator<PhotoIdRequest>
    {
        public PhotoIdValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage(Messages.PhotoIdNotNull);
        }
    }
}

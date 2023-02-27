using Core.Utilities.Messages;
using Entities.Dtos.Requests.Photo;
using FluentValidation;

namespace WebAPI.Validation.Photo
{
    public class PhotoForCreationValidator : AbstractValidator<PhotoForCreationRequest>
    {
        public PhotoForCreationValidator()
        {
            RuleFor(p => p.File).NotEmpty().NotNull().WithMessage(Messages.PhotoFileNotNull);
            RuleFor(p => p.Description).NotEmpty().NotNull().WithMessage(Messages.PhotoDescriptionNotNull);
        }
    }
}

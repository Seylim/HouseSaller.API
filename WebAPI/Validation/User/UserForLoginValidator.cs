using Core.Utilities.Messages;
using Entities.Dtos.Requests.UserDtos;
using FluentValidation;

namespace WebAPI.Validation.User
{
    public class UserForLoginValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginValidator()
        {
            RuleFor(u => u.Email).NotNull().NotEmpty().WithMessage(Messages.UserEmailNotNull);
            RuleFor(u => u.Email).EmailAddress().WithMessage(Messages.UserEmailNotValid);
            RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage(Messages.UserPasswordNotNull);
        }
    }
}

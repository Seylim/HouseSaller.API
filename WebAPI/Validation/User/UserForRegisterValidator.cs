using Core.Utilities.Messages;
using Entities.Dtos.Requests.UserDtos;
using FluentValidation;

namespace WebAPI.Validation.User
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(u => u.FirstName).NotNull().NotEmpty().WithMessage(Messages.UserFirstNameNotNull);
            RuleFor(u => u.LastName).NotNull().NotEmpty().WithMessage(Messages.UserLastNameNotNull);
            RuleFor(u => u.Email).NotNull().NotEmpty().WithMessage(Messages.UserEmailNotNull);
            RuleFor(u => u.Email).EmailAddress().WithMessage(Messages.UserEmailNotValid);
            RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage(Messages.UserPasswordNotNull);
            RuleFor(u => u.Password).MaximumLength(16).WithMessage(Messages.UserpasswordMaxLength);
            RuleFor(u => u.Password).MinimumLength(6).WithMessage(Messages.UserpasswordMinLength);
        }
    }
}

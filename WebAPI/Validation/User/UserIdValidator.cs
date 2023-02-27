using Core.Utilities.Messages;
using Entities.Dtos.Requests.UserDtos;
using FluentValidation;

namespace WebAPI.Validation.User
{
    public class UserIdValidator : AbstractValidator<UserIdRequest>
    {
        public UserIdValidator()
        {
            RuleFor(u => u.Id).NotNull().NotEmpty().WithMessage(Messages.UserIdNotNull);
        }
    }
}

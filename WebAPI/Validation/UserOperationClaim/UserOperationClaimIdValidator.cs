using Core.Utilities.Messages;
using Entities.Dtos.Requests.UserOperationClaimDtos;
using FluentValidation;

namespace WebAPI.Validation.UserOperationClaim
{
    public class UserOperationClaimIdValidator : AbstractValidator<UserOperationClaimIdRequest>
    {
        public UserOperationClaimIdValidator()
        {
            RuleFor(uoc => uoc.Id).NotEmpty().NotNull().WithMessage(Messages.UserOperationClaimIdNotNull);
        }
    }
}

using Core.Utilities.Messages;
using Entities.Dtos.Requests.UserOperationClaimDtos;
using FluentValidation;

namespace WebAPI.Validation.UserOperationClaim
{
    public class AddUserOperationClaimValidator : AbstractValidator<AddUserOperationClaimRequest>
    {
        public AddUserOperationClaimValidator()
        {
            RuleFor(uoc => uoc.UserId).NotEmpty().NotNull().WithMessage(Messages.UserIdNotNull);
            RuleFor(uoc => uoc.OperationClaimId).NotEmpty().NotNull().WithMessage(Messages.OperationClaimIdNotNull);
        }
    }
}

using Core.Utilities.Messages;
using Entities.Dtos.Requests.OperationClaimDtos;
using FluentValidation;

namespace WebAPI.Validation.OperationClaim
{
    public class OperationClaimIdValidator : AbstractValidator<OperationClaimIdRequest>
    {
        public OperationClaimIdValidator()
        {
            RuleFor(oc => oc.Id).NotEmpty().NotNull().WithMessage(Messages.OperationClaimIdNotNull);
        }
    }
}

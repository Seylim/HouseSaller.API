using Core.Utilities.Messages;
using Entities.Dtos.Requests.OperationClaimDtos;
using FluentValidation;

namespace WebAPI.Validation.OperationClaim
{
    public class UpdateOperationClaimValidator : AbstractValidator<UpdateOperationClaimRequest>
    {
        public UpdateOperationClaimValidator()
        {
            RuleFor(oc => oc.Id).NotEmpty().NotNull().WithMessage(Messages.OperationClaimIdNotNull);
            RuleFor(oc => oc.Name).NotEmpty().NotNull().WithMessage(Messages.OperationClaimNameNotNull);
        }
    }
}

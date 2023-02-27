using Core.Utilities.Messages;
using Entities.Dtos.Requests.OperationClaimDtos;
using FluentValidation;

namespace WebAPI.Validation.OperationClaim
{
    public class AddOperationClaimValidator : AbstractValidator<AddOperationClaimRequest>
    {
        public AddOperationClaimValidator()
        {
            RuleFor(oc  => oc.Name).NotEmpty().NotNull().WithMessage(Messages.OperationClaimNameNotNull);
        }
    }
}

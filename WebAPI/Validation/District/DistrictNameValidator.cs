using Core.Utilities.Messages;
using Entities.Dtos.Requests.DistrictDtos;
using FluentValidation;

namespace WebAPI.Validation.District
{
    public class DistrictNameValidator : AbstractValidator<DistrictNameRequest>
    {
        public DistrictNameValidator()
        {
            RuleFor(d => d.Name).NotNull().NotEmpty().WithMessage(Messages.DistrictNameNotNull);
        }
    }
}

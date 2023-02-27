using Core.Utilities.Messages;
using Entities.Dtos.Requests.DistrictDtos;
using FluentValidation;

namespace WebAPI.Validation.District
{
    public class DistrictIdValidator : AbstractValidator<DistrictIdRequest>
    {
        public DistrictIdValidator()
        {
            RuleFor(d => d.Id).NotEmpty().NotNull().WithMessage(Messages.DistrictIdNotNull);
        }
    }
}

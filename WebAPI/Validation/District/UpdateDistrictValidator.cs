using Core.Utilities.Messages;
using Entities.Dtos.Requests.DistrictDtos;
using FluentValidation;

namespace WebAPI.Validation.District
{
    public class UpdateDistrictValidator : AbstractValidator<UpdateDistrictRequest>
    {
        public UpdateDistrictValidator()
        {
            RuleFor(d => d.Id).NotEmpty().NotNull().WithMessage(Messages.DistrictIdNotNull);
            RuleFor(d => d.CityId).NotEmpty().NotNull().WithMessage(Messages.CityIdNotNull);
            RuleFor(d => d.Name).NotEmpty().NotNull().WithMessage(Messages.DistrictNameNotNull);
        }
    }
}

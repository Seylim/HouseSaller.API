﻿using Core.Utilities.Messages;
using Entities.Dtos.Requests.CityDtos;
using FluentValidation;

namespace WebAPI.Validation.City
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityRequest>
    {
        public UpdateCityValidator()
        {
            RuleFor(cty => cty.Id).NotEmpty().NotNull().WithMessage(Messages.CityIdNotNull);
            RuleFor(cty => cty.Name).NotEmpty().NotNull().WithMessage(Messages.CityNameNotNull);
            RuleFor(cty => cty.Name).MaximumLength(20).WithMessage(Messages.CityNameLength);
            RuleFor(cty => cty.NumberPlate).NotEmpty().NotNull().WithMessage(Messages.CityNumberPlateNotNull);
            RuleFor(cty => cty.TelephoneCode).NotEmpty().NotNull().WithMessage(Messages.CityTelephoneCodeNotNull);
        }
    }
}

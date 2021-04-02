using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2);
            RuleFor(p => p.CarName).MaximumLength(50);
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.ModelYear).LessThanOrEqualTo(2015);
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo(DateTime.Now.Year+1);
            RuleFor(p => p.Plaka).NotEmpty();
            RuleFor(p => p.Plaka).MinimumLength(2);
            RuleFor(p => p.Plaka).MaximumLength(20);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.Description).MaximumLength(200);

        }
    }
}

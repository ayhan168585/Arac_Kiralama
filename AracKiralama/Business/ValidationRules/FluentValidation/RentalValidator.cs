using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.CreditCardId).NotEmpty();
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.RentDate).NotEmpty();
            RuleFor(p => p.RentDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(p => p.RentDate <= p.ReturnDate);
            RuleFor(p => p.ReturnDate >= p.RentDate);
            RuleFor(p => p.RentPrice).NotEmpty();
            RuleFor(p => p.RentPrice).LessThanOrEqualTo(0);

        }
    }
}

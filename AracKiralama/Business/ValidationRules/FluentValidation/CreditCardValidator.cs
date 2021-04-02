using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(p => p.BankId).NotEmpty();
            RuleFor(p => p.CreditCardNumber).NotEmpty();
            RuleFor(p => p.CreditCardNumber).MinimumLength(2);
            RuleFor(p => p.CreditCardNumber).MaximumLength(50);
            RuleFor(p => p.CCV).NotEmpty();
            RuleFor(p => p.CCV).MinimumLength(1);
            RuleFor(p => p.CCV).MaximumLength(10);
            RuleFor(p => p.ValidDate).NotEmpty();
            RuleFor(p => p.ValidDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(p => p.Deposit).NotEmpty();
            RuleFor(p => p.Deposit).LessThanOrEqualTo(0);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.Description).MaximumLength(200);
        }
    }
}

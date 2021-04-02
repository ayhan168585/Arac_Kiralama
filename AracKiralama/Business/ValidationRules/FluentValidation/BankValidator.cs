using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BankValidator:AbstractValidator<Bank>
    {
        public BankValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.BankName).NotEmpty();
            RuleFor(p => p.BankName).MinimumLength(2);
            RuleFor(p => p.BankName).MaximumLength(200);
            RuleFor(p => p.AccountNumber).NotEmpty();
            RuleFor(p => p.AccountNumber).MinimumLength(2);
            RuleFor(p => p.AccountNumber).MaximumLength(50);

        }
    }
}

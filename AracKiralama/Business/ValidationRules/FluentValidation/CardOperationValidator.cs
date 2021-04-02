using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CardOperationValidator:AbstractValidator<CardOperation>
    {
        public CardOperationValidator()
        {
            RuleFor(p => p.CreditCardId).NotEmpty();
            RuleFor(p => p.OperationName).NotEmpty();
            RuleFor(p => p.OperationName).MinimumLength(2);
            RuleFor(p => p.OperationName).MaximumLength(200);
            RuleFor(p => p.OperationPrice).NotEmpty();
            RuleFor(p => p.OperationPrice).LessThanOrEqualTo(0);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.Description).MaximumLength(200);
          
        }
    }
}

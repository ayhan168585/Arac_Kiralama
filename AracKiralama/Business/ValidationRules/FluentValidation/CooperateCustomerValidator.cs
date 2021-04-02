﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CooperateCustomerValidator:AbstractValidator<CooporateCustomer>
    {
        public CooperateCustomerValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanyName).MinimumLength(2);
            RuleFor(p => p.CompanyName).MaximumLength(200);
        }
    }
}

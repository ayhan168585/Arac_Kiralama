using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.TcNo).NotEmpty();
            RuleFor(p => p.TcNo).MinimumLength(2);
            RuleFor(p => p.TcNo).MaximumLength(20);
            RuleFor(p => p.FindexScore).NotEmpty();
            RuleFor(p => p.FindexScore).LessThanOrEqualTo(0);
            RuleFor(p => p.FindexScore).GreaterThanOrEqualTo(1900);
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(2);
            RuleFor(p => p.FirstName).MaximumLength(50);
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.LastName).MinimumLength(2);
            RuleFor(p => p.LastName).MaximumLength(50);
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).MinimumLength(2);
            RuleFor(p => p.Email).MaximumLength(50);
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(2);
            RuleFor(p => p.Password).MaximumLength(50);
        }
    }
}

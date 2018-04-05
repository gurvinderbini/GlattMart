using System;
using FluentValidation;
using GlattMart.Models;

namespace GlattMart.Validator
{
    [FluentValidation.Attributes.Validator(typeof(ForgotPasswordValidator))]
    public class ForgotPasswordValidator: AbstractValidator<ForgotPasswordParamModel>
    {
        public ForgotPasswordValidator()
        {
            
            RuleFor(x => x.Email).NotNull().Length(5, 20);
        }
    }
}
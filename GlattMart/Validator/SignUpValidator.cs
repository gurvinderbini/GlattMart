using System;
using FluentValidation;
using GlattMart.Models;

namespace GlattMart
{
    [FluentValidation.Attributes.Validator(typeof(SignUpValidator))]
    public class SignUpValidator : AbstractValidator<SignupValidatorModel>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.FirstName).NotNull().Length(5, 40);
            RuleFor(x => x.LastName).NotNull().Length(5, 40);
            RuleFor(x => x.Email).NotNull().Length(5,35);
            RuleFor(x => x.Password).NotNull().Length(5,15);
            RuleFor(x => x.MobileNo).NotNull().Length(10);
        }
    }
}
using System;
using FluentValidation;
using GlattMart.Models;

namespace GlattMart
{
    [FluentValidation.Attributes.Validator(typeof(SinginValidator))]
    public class SinginValidator : AbstractValidator<SignInValidatorModel>
    {
        public SinginValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Password).NotNull();
        }
    }
}
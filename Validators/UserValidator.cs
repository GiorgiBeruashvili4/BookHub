using BookHub.Models.Derived;
using FluentValidation;

namespace BookHub.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("ID Is Required.")
            .Length(11).WithMessage("ID Must Be 11-Digit Long.");

        RuleFor(a => a.FullName)
            .MinimumLength(2).WithMessage("Full Name Requires At Least 2 Symbols.");

        RuleFor(a => a.Email)
            .EmailAddress().WithMessage("Email Requires A Valid Email.");

        RuleFor(a => a.Address)
            .NotEmpty().WithMessage("Address Is Required.");

        RuleFor(a => a.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number Is Required.")
            .MinimumLength(9).WithMessage("Phone Number Requires At Least 9 Digits.");
    }
}

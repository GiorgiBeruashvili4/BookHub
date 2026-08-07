using FluentValidation;

namespace BookHub.Validators;

public class EmailValidator : AbstractValidator<string>
{
    public EmailValidator()
    {
        RuleFor(e => e)
            .NotEmpty().WithMessage("Email Is Required")
            .EmailAddress().WithMessage("Email Requires A Valid Email.");
    }
}

using FluentValidation;

namespace BookHub.Validators;

public class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator()
    {
        RuleFor(p => p)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(10).WithMessage("Password Must Be At Least 10 Characters Long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase symbol.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase symbol.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.");
    }
}

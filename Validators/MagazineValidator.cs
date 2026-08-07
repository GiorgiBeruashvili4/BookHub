using BookHub.Models.Derived;
using FluentValidation;

namespace BookHub.Validators;

public class MagazineValidator : AbstractValidator<Magazine>
{
    public MagazineValidator()
    {
        RuleFor(m => m.Title)
            .NotEmpty().WithMessage("Title Is Required.");

        RuleFor(m => m.Author)
            .NotEmpty().WithMessage("Author Is Required.");

        RuleFor(m => m.Genre)
            .NotEmpty().WithMessage("Genre Is Required.");

        RuleFor(m => m.PublishYear)
            .NotEmpty().WithMessage("Publish Year Is Required.")
            .LessThan(DateTime.Now.Year).WithMessage($"Year Must Be Less Than {DateTime.Now.Year}.");

        RuleFor(m => m.TotalCopies)
            .NotEmpty().WithMessage("Total Copies Is Required.")
            .GreaterThan(0).WithMessage("Total Copies must be greater than 0.");

        RuleFor(m => m.IssueNumber)
            .NotEmpty().WithMessage("Issue Number Is Required.");
    }
}

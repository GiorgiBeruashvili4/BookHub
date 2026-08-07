using BookHub.Models.Derived;
using FluentValidation;

namespace BookHub.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Title Is Required.");

        RuleFor(b => b.Author)
            .NotEmpty().WithMessage("Author Is Required.");

        RuleFor(b => b.Genre)
            .NotEmpty().WithMessage("Genre Is Required.");

        RuleFor(b => b.PublishYear)
            .NotEmpty().WithMessage("Publish Year Is Required.")
            .LessThan(DateTime.Now.Year).WithMessage($"Year Must Be Less Than {DateTime.Now.Year}.");

        RuleFor(b => b.TotalCopies)
            .NotEmpty().WithMessage("Total Copies Is Required.")
            .GreaterThan(0).WithMessage("Total Copies must be greater than 0.");

        RuleFor(b => b.Pages)
            .NotEmpty().WithMessage("Pages Is Required.")
            .GreaterThan(0).WithMessage("Pages must be greater than 0.");

        RuleFor(b => b.ISBN)
            .NotEmpty().WithMessage("ISBN Is Required.");
    }
}

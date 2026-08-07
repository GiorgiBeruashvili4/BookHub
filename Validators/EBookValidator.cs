using BookHub.Models.Derived;
using FluentValidation;

namespace BookHub.Validators;

public class EBookValidator : AbstractValidator<EBook>
{
    public EBookValidator()
    {
        RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title Is Required.");

        RuleFor(e => e.Author)
            .NotEmpty().WithMessage("Author Is Required.");

        RuleFor(e => e.Genre)
            .NotEmpty().WithMessage("Genre Is Required.");

        RuleFor(e => e.PublishYear)
            .NotEmpty().WithMessage("Publish Year Is Required.")
            .LessThan(DateTime.Now.Year).WithMessage($"Year Must Be Less Than {DateTime.Now.Year}.");

        RuleFor(e => e.TotalCopies)
            .NotEmpty().WithMessage("Total Copies Is Required.")
            .GreaterThan(0).WithMessage("Total Copies must be greater than 0.");

        RuleFor(e => e.FileFormat)
            .NotEmpty().WithMessage("File Format Is Required.");

        RuleFor(e => e.FileSizeMB)
            .NotEmpty().WithMessage("File Size Is Required.")
            .GreaterThan(0).WithMessage("File Size must be greater than 0.");
    }
}

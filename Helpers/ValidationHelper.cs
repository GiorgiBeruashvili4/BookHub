using FluentValidation;
using FluentValidation.Results;

namespace BookHub.Helpers;

public static class ValidationHelper
{
    public static bool PrintValidationResult(ValidationResult result)
    {
        if (result.IsValid)
        {
            return true;
        }

        Console.ForegroundColor = ConsoleColor.Red;

        foreach(var error in result.Errors)
        {
            Console.WriteLine(error.ErrorMessage);
        }

        Console.ResetColor();

        return false;
    }
}

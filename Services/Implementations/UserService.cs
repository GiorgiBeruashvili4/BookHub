using BookHub.Enums;
using BookHub.Helpers;
using BookHub.Models;
using BookHub.Models.Derived;
using BookHub.Validators;
using FluentValidation.Results;

namespace BookHub.Services.Implementations;

public static class UserService
{
    public static void CurrentlyBorrowedItems(User user)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Currently Borrowed Items ***");
        Console.ForegroundColor = ConsoleColor.White;

        List<BorrowRecord> result = JsonHelper.ReadRecords().Where(r=>r.UserId == user.Id && !r.IsReturned).ToList();

        if(result.Count == 0)
        {
            Console.WriteLine("Currently You Have No Items Borrowed");
            return;
        }

        foreach(BorrowRecord record in result)
        {
            Console.WriteLine(record);
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", user.Id, $"Viewed Currently Borrowed Items ({result.Count} Items)");

        Console.ResetColor();
    }

    public static void BorrowHistory(User user)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Borrow History ***");
        Console.ForegroundColor = ConsoleColor.White;

        List<BorrowRecord> result = JsonHelper.ReadRecords().Where(r => r.UserId == user.Id).ToList();

        if (result.Count == 0)
        {
            Console.WriteLine("You Have No Borrow History Yet");
            return;
        }

        foreach (BorrowRecord record in result)
        {
            Console.WriteLine(record);
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", user.Id, $"Viewed Borrow History ({result.Count} Records)");

        Console.ResetColor();
    }

    public static void OverdueItemsAndFines(User user)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Overdue Books & Fines ***");
        Console.ForegroundColor = ConsoleColor.White;

        List<BorrowRecord> result = JsonHelper.ReadRecords().Where(r => r.UserId == user.Id && r.IsOverdue()).ToList();

        if (result.Count == 0)
        {
            Console.WriteLine("You Have No Overdue Items & Fines");
            return;
        }

        foreach (BorrowRecord record in result)
        {
            Console.WriteLine(record);
        }

        LoggingHelper.WriteLog(LogLevel.Warning, "User", user.Id, $"Has {result.Count} Overdue Items");

        Console.ResetColor();
    }

    public static void ViewProfile(User user)
    {
        List<BorrowRecord> records = JsonHelper.ReadRecords();

        decimal sum = 0;
        foreach (BorrowRecord record in records)
        {
            if(record.UserId == user.Id)
            {
                sum += record.FineAmount;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"Totale Fines: {sum}$\n");
        Console.WriteLine();

        CurrentlyBorrowedItems(user);
        Console.WriteLine();
        OverdueItemsAndFines(user);
        Console.WriteLine();
        BorrowHistory(user);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n*** Returned Items ***");
        Console.ForegroundColor = ConsoleColor.White;

        foreach (BorrowRecord record in records)
        {
            if (record.UserId == user.Id && record.IsReturned)
            {
                Console.WriteLine(record);
            }
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", user.Id, "Viewed Their Profile");

        Console.ResetColor();
    }

    public static void ChangePassword(User user)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Current Password: ");
        string currentPassword = ConsoleHelper.HidePassword();

        if (user.Verify(currentPassword))
        {
            Console.Write("Enter New Password: ");
            string newPassword = ConsoleHelper.HidePassword();

            PasswordValidator validator = new PasswordValidator();
            ValidationResult result = validator.Validate(newPassword);

            if (!ValidationHelper.PrintValidationResult(result))
            {
                LoggingHelper.WriteLog(LogLevel.Warning, "User", user.Id, "Failed Password Change Attempt (New Password Did Not Meet Requirements)");
                MenuHelper.Wait();
                return;
            }

            user.SetPassword(newPassword);
            JsonHelper.UpdateUser(user);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("Password Changed Successfully");

            LoggingHelper.WriteLog(LogLevel.Info, "User", user.Id, "Changed Their Password");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("Current Password Is Incorrect");

            LoggingHelper.WriteLog(LogLevel.Warning, "User", user.Id, "Failed Password Change Attempt (Error: Incorrect Current Password)");
        }

        Console.ResetColor();
    }
}

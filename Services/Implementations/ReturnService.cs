using BookHub.Enums;
using BookHub.Helpers;
using BookHub.Models;
using BookHub.Models.Base;
using BookHub.Models.Derived;

namespace BookHub.Services.Implementations;

public static class ReturnService
{
    public static void Return(User user)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Item ID: ");
        string id = Console.ReadLine();

        List<LibraryItem> allItems = JsonHelper.ReadData();
        LibraryItem item = allItems.FirstOrDefault(i => i.Id == id);

        if (item == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Item Not Found");
            Console.ResetColor();

            LoggingHelper.WriteLog(LogLevel.Warning, "User", user.Id, $"Attempted To Return Non-Existent Item [{id}]");

            return;
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        if (item is Book)
        {
            List<Book> books = JsonHelper.ReadBooks();
            Book book = books.FirstOrDefault(b => b.Id == id);
            book.Return();
            Console.Clear();
            Console.WriteLine($"'{book.Title}' Returned Successfully");
            JsonHelper.WriteBooks(books);
        }
        else if (item is Magazine)
        {
            List<Magazine> magazines = JsonHelper.ReadMagazines();
            Magazine magazine = magazines.FirstOrDefault(m => m.Id == id);
            magazine.Return();
            Console.Clear();
            Console.WriteLine($"'{magazine.Title}' Returned Successfully");
            JsonHelper.WriteMagazines(magazines);
        }
        else if (item is EBook)
        {
            List<EBook> eBooks = JsonHelper.ReadEBooks();
            EBook eBook = eBooks.FirstOrDefault(e => e.Id == id);
            eBook.Return();
            Console.Clear();
            Console.WriteLine($"'{eBook.Title}' Returned Successfully");
            JsonHelper.WriteEBooks(eBooks);
        }

        List<BorrowRecord> records = JsonHelper.ReadRecords();
        BorrowRecord record = records.FirstOrDefault(r => r.UserId == user.Id && r.LibraryItemId == id && !r.IsReturned);

        Console.ForegroundColor = ConsoleColor.Red;
        if (record != null)
        {
            record.MarkAsReturned();
            JsonHelper.WriteRecords(records);

            if(record.FineAmount > 0)
            {
                Console.WriteLine($"This Item Was Overdue. Fine: {record.FineAmount}$");
                LoggingHelper.WriteLog(LogLevel.Warning, "User", user.Id, $"Returned Item [{id}] Late, Fined {record.FineAmount}$");
            }
            else
            {
                LoggingHelper.WriteLog(LogLevel.Info, "User", user.Id, $"Returned Item [{id}] Successfully");
            }
        }

        Console.ResetColor();
    }
}

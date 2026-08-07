using BookHub.Enums;
using BookHub.Helpers;
using BookHub.Models;
using BookHub.Models.Base;
using BookHub.Models.Derived;

namespace BookHub.Services.Implementations;

public static class BorrowService
{
    public static void Borrow(User user)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Item Id: ");
        string id = Console.ReadLine();

        List<LibraryItem> allItems = JsonHelper.ReadData();
        LibraryItem item = allItems.FirstOrDefault(i => i.Id == id);

        if(item == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Item Not Found");
            Console.ResetColor();

            LoggingHelper.WriteLog(LogLevel.Warning, "User", user.Id, $"Attempted To Borrow Non-Existent Item [{id}]");

            return;
        }

        bool borrowed = false;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        if(item is Book)
        {
            List<Book> books = JsonHelper.ReadBooks();
            Book book = books.FirstOrDefault(b => b.Id == id);
            borrowed = TryBorrow(book);
            JsonHelper.WriteBooks(books);
        }
        else if(item is Magazine)
        {
            List<Magazine> magazines = JsonHelper.ReadMagazines();
            Magazine magazine = magazines.FirstOrDefault(m => m.Id == id);
            borrowed = TryBorrow(magazine);
            JsonHelper.WriteMagazines(magazines);
        }
        else if (item is EBook)
        {
            List<EBook> eBooks = JsonHelper.ReadEBooks();
            EBook eBook = eBooks.FirstOrDefault(e => e.Id == id);
            borrowed = TryBorrow(eBook);
            JsonHelper.WriteEBooks(eBooks);
        }

        if (borrowed)
        {
            BorrowRecord newRecord = BorrowRecord.CreateRecord(Guid.NewGuid().ToString(), user.Id, id);
            List<BorrowRecord> records = JsonHelper.ReadRecords();
            records.Add(newRecord);
            JsonHelper.WriteRecords(records);

            LoggingHelper.WriteLog(LogLevel.Info, "User", user.Id, $"Borrowed Item [{id}] Successfully");
        }
        else
        {
            LoggingHelper.WriteLog(LogLevel.Warning, "User", user.Id, $"Failed To Borrow Item [{id}] (unavailable)");
        }

        Console.ResetColor();
    }

    private static bool TryBorrow(LibraryItem item)
    {
        if (item.Borrow())
        {
            Console.Clear();
            Console.WriteLine($"'{item.Title}' Borrowed Successfully.");
            return true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"'{item.Title}' Is Currently Unavailable (0 Copies Left).");
            return false;
        }
    }
}

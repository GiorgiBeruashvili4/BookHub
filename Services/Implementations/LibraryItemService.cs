using BookHub.Enums;
using BookHub.Helpers;
using BookHub.Models.Base;
using BookHub.Models.Derived;

namespace BookHub.Services.Implementations;

public static class LibraryItemService
{
    public static void ShowAllItems()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Catalog ***");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (LibraryItem i in JsonHelper.ReadData())
        {
            Console.WriteLine(i);
        }

        Console.ResetColor();
    }

    public static void SearchByTitle(string userId)
    {
        Console.ForegroundColor= ConsoleColor.White;

        Console.Write("Enter Title: ");
        string title = Console.ReadLine().Trim();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Search Results For: {title}");
        Console.ForegroundColor = ConsoleColor.White;

        List<LibraryItem> byTitle = JsonHelper.ReadData().Where(x => x.Title.ToLower() == title.ToLower()).ToList();

        if(byTitle.Count > 0)
        {
            foreach (LibraryItem i in byTitle)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("No Results Found");
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", userId, $"Searched By Title '{title}'");

        Console.ResetColor();
    }

    public static void SearchByAuthor(string userId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Author: ");
        string author = Console.ReadLine().Trim();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Search Results For: {author}");
        Console.ForegroundColor = ConsoleColor.White;

        List<LibraryItem> byAuthor = JsonHelper.ReadData().Where(x => x.Author.ToLower() == author.ToLower()).ToList();

        if (byAuthor.Count > 0)
        {
            foreach (LibraryItem i in byAuthor)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("No Results Found");
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", userId, $"Searched By Author '{author}'");

        Console.ResetColor();
    }

    public static void SearchByGenre(string userId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine().Trim();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Search Results For: {genre}");
        Console.ForegroundColor = ConsoleColor.White;

        List<LibraryItem> byGenre = JsonHelper.ReadData().Where(x => x.Genre.ToLower() == genre.ToLower()).ToList();

        if (byGenre.Count > 0)
        {
            foreach (LibraryItem i in byGenre)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("No Results Found");
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", userId, $"Searched By Genre '{genre}'");

        Console.ResetColor();
    }

    public static void SearchByPublishYear(string userId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Publish Year: ");
        if(!int.TryParse(Console.ReadLine().Trim(), out int year))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid Input");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Search Results For: {year}");
        Console.ForegroundColor = ConsoleColor.White;

        List<LibraryItem> byYear = JsonHelper.ReadData().Where(x => x.PublishYear == year).ToList();

        if (byYear.Count > 0)
        {
            foreach (LibraryItem i in byYear)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("No Results Found");
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", userId, $"Searched By Publish Year '{year}'");

        Console.ResetColor();
    }

    public static void ShowAvailableItems()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Available Items ***");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (LibraryItem i in JsonHelper.ReadData())
        {
            if (i.IsAvailable())
            {
                Console.WriteLine(i);
            }
        }

        Console.ResetColor();
    }

    public static void SortByTitleAsc(string userId)
    {
        List<LibraryItem> sorted = JsonHelper.ReadData().OrderBy(x => x.Title).ToList();


        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Sorted By Title (A-Z) ***");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (LibraryItem i in sorted)
        {
            Console.WriteLine(i);
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", userId, "Sorted Items By Title (A-Z)");

        Console.ResetColor();
    }

    public static void SortByTitleDesc(string userId)
    {
        List<LibraryItem> sorted = JsonHelper.ReadData().OrderByDescending(x => x.Title).ToList();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Sorted By Title (Z-A) ***");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (LibraryItem i in sorted)
        {
            Console.WriteLine(i);
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", userId, "Sorted Items By Title (Z-A)");

        Console.ResetColor();
    }

    public static void SortByYearAsc(string userId)
    {
        List<LibraryItem> sorted = JsonHelper.ReadData().OrderBy(x => x.PublishYear).ToList();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Sorted By Publish Year (Oldest-Newest) ***");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (LibraryItem i in sorted)
        {
            Console.WriteLine(i);
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", userId, "Sorted Items By Publish Year (Oldest-Newest)");

        Console.ResetColor();
    }

    public static void SortByYearDesc(string userId)
    {
        List<LibraryItem> sorted = JsonHelper.ReadData().OrderByDescending(x => x.PublishYear).ToList();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Sorted By Publish Year (Newest-Oldest) ***");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (LibraryItem i in sorted)
        {
            Console.WriteLine(i);
        }

        LoggingHelper.WriteLog(LogLevel.Info, "User", userId, "Sorted Items By Publish Year (Neweset-Oldest)");

        Console.ResetColor();
    }

    public static void FilterByTitle(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Title: ");
        string title = Console.ReadLine().Trim().ToLower();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Results For: {title}");
        Console.ResetColor();

        List<LibraryItem> items = JsonHelper.ReadData().Where(i => i.Title.ToLower() == title || i.Title.ToLower().StartsWith(title)).ToList();

        if (items.Count > 0)
        {
            foreach (LibraryItem i in items)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("No Results Found");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Filtered Catalog By Title '{title}'");

        Console.ResetColor();
    }

    public static void FilterByAuthor(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Author: ");
        string author = Console.ReadLine().Trim().ToLower();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Results For: {author}");
        Console.ResetColor();

        List<LibraryItem> items = JsonHelper.ReadData().Where(i => i.Author.ToLower() == author || i.Author.ToLower().StartsWith(author)).ToList();

        if (items.Count > 0)
        {
            foreach (LibraryItem i in items)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("No Results Found");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Filtered Catalog By Author '{author}'");

        Console.ResetColor();
    }

    public static void FilterByGenre(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine().Trim().ToLower();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Results For: {genre}");
        Console.ResetColor();

        List<LibraryItem> items = JsonHelper.ReadData().Where(i => i.Genre.ToLower() == genre || i.Genre.ToLower().StartsWith(genre)).ToList();

        if (items.Count > 0)
        {
            foreach (LibraryItem i in items)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("No Results Found");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Filtered Catalog By Genre '{genre}'");

        Console.ResetColor();
    }

    public static void FilterByYear(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Year: ");
        if (!int.TryParse(Console.ReadLine().Trim(), out int year))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid Input");
            Console.ResetColor();
            return;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Results For: {year}");
        Console.ResetColor();

        List<LibraryItem> items = JsonHelper.ReadData().Where(i => i.PublishYear == year || i.PublishYear.ToString().StartsWith(year.ToString())).ToList();

        if (items.Count > 0)
        {
            foreach (LibraryItem i in items)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            Console.WriteLine("No Results Found");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Filtered Catalog By Publish Year '{year}'");

        Console.ResetColor();
    }

    public static void OnlyBooks(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Books ***");
        Console.ForegroundColor = ConsoleColor.White;

        List<Book> books = JsonHelper.ReadBooks();

        if (books.Count > 0)
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("No Books Found");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed Only Books");

        Console.ResetColor();
    }

    public static void OnlyMagazines(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Magazines ***");
        Console.ForegroundColor = ConsoleColor.White;

        List<Magazine> magazines = JsonHelper.ReadMagazines();

        if (magazines.Count > 0)
        {
            foreach (Magazine magazine in magazines)
            {
                Console.WriteLine(magazine);
            }
        }
        else
        {
            Console.WriteLine("No Magazines Found");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed Only Magazines");

        Console.ResetColor();
    }

    public static void OnlyEBooks(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** EBooks ***");
        Console.ForegroundColor = ConsoleColor.White;

        List<EBook> eBooks = JsonHelper.ReadEBooks();

        if (eBooks.Count > 0)
        {
            foreach (EBook eBook in eBooks)
            {
                Console.WriteLine(eBook);
            }
        }
        else
        {
            Console.WriteLine("No EBooks Found");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed Only EBooks");

        Console.ResetColor();
    }
}

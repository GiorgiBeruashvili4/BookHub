using BookHub.Helpers;
using BookHub.Models;
using BookHub.Models.Base;
using BookHub.Models.Derived;
using BookHub.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace BookHub.Services.Implementations;

public static class AdminService
{
    public static void AddNewBook(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        int year = ConsoleHelper.ValidateInt("Publish Year: ");
        int total = ConsoleHelper.ValidateInt("Total Copies: ");
        int pages = ConsoleHelper.ValidateInt("Pages: ");

        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();

        List<Book> books = JsonHelper.ReadBooks();
        string newId = Book.GenerateId(books);

        Book newBook = new Book(newId, title, author, genre, year, total, total, pages, isbn);

        BookValidator validator = new BookValidator();
        ValidationResult result = validator.Validate(newBook);

        if (!ValidationHelper.PrintValidationResult(result))
        {
            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Validation Error While Adding New Book");
            return;
        }

        books.Add(newBook);
        JsonHelper.WriteBooks(books);

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Added New Book: [{newId}]");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Book Added Successfully With ID: {newId}");
        Console.ResetColor();
    }

    public static void AddNewMagazine(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        int year = ConsoleHelper.ValidateInt("Publish Year: ");
        int total = ConsoleHelper.ValidateInt("Total Copies: ");

        Console.Write("Issue Number: ");
        string number = Console.ReadLine();

        List<Magazine> magazines = JsonHelper.ReadMagazines();
        string newId = Magazine.GenerateId(magazines);

        Magazine newMagazine = new Magazine(newId, title, author, genre, year, total, total, number);

        MagazineValidator validator = new MagazineValidator();
        ValidationResult result = validator.Validate(newMagazine);

        if (!ValidationHelper.PrintValidationResult(result))
        {
            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Validation Error While Adding New Magazine");
            return;
        }

        magazines.Add(newMagazine);
        JsonHelper.WriteMagazines(magazines);

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Added New Magazine: [{newId}]");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Magazine Added Successfully With ID: {newId}");
        Console.ResetColor();
    }

    public static void AddNewEBook(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        int year = ConsoleHelper.ValidateInt("Publish Year: ");
        int total = ConsoleHelper.ValidateInt("Total Copies: ");

        Console.Write("File Format: ");
        string format = Console.ReadLine();

        double size;
        while (true)
        {
            Console.Write("Size(MB): ");
            if((double.TryParse(Console.ReadLine(), out size)))
            {
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid Input");
            Console.ResetColor();
        }

        List<EBook> eBooks = JsonHelper.ReadEBooks();
        string newId = EBook.GenerateId(eBooks);

        EBook newEBook = new EBook(newId, title, author, genre, year, total, total, format, size);

        EBookValidator validator = new EBookValidator();
        ValidationResult result = validator.Validate(newEBook);

        if (!ValidationHelper.PrintValidationResult(result))
        {
            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Validation Error While Adding New EBook");
            return;
        }

        eBooks.Add(newEBook);
        JsonHelper.WriteEBooks(eBooks);

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Added New EBook: [{newId}]");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"EBook Added Successfully With ID: {newId}");
        Console.ResetColor();
    }

    public static void DeleteItem(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Item ID: ");
        string id = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        if (id.StartsWith("B"))
        {
            List<Book> books = JsonHelper.ReadBooks();
            int removed = books.RemoveAll(b => b.Id == id);
            JsonHelper.WriteBooks(books);

            if (removed > 0)
            {
                Console.Clear();
                Console.WriteLine("Book Deleted Successfully");
                LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Deleted Book: [{id}]");
            }
            else
            {
                Console.WriteLine("Book Not Found");
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Attempted To Delete Non-Existent Book: [{id}]");
            }
        }
        else if (id.StartsWith("M"))
        {
            List<Magazine> magazines = JsonHelper.ReadMagazines();
            int removed = magazines.RemoveAll(m => m.Id == id);
            JsonHelper.WriteMagazines(magazines);

            if (removed > 0)
            {
                Console.Clear();
                Console.WriteLine("Magazine Deleted Successfully");
                LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Deleted Magazine: [{id}]");
            }
            else
            {
                Console.WriteLine("Magazine Not Found");
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Attempted To Delete Non-Existent Magazine: [{id}]");
            }
        }
        else if (id.StartsWith("E"))
        {
            List<EBook> eBooks = JsonHelper.ReadEBooks();
            int removed = eBooks.RemoveAll(e => e.Id == id);
            JsonHelper.WriteEBooks(eBooks);

            if (removed > 0)
            {
                Console.Clear();
                Console.WriteLine("EBook Deleted Successfully");
                LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Deleted EBook: [{id}]");
            }
            else
            {
                Console.WriteLine("EBook Not Found");
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Attempted To Delete Non-Existent EBook: [{id}]");
            }
        }

        Console.ResetColor();
    }

    public static void EditItem(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Item ID: ");
        string id = Console.ReadLine();

        List<LibraryItem> allItems = JsonHelper.ReadData();
        LibraryItem item = allItems.FirstOrDefault(i => i.Id == id);

        if(item == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Item Not Found");
            Console.ResetColor();

            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Attempted To Edit Non-Existent Item: [{id}]");

            return;
        }

        Console.Clear();
        Console.WriteLine($"Editing: {item}");
        Console.WriteLine("* Leave Field Blank To Keep Its Current Value\n");

        Console.Write($"Title({item.Title}): ");
        string title = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title))
        {
            title = item.Title;
        }

        Console.Write($"Author({item.Author}): ");
        string author = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(author))
        {
            author = item.Author;
        }

        Console.Write($"Genre({item.Genre}): ");
        string genre = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(genre))
        {
            genre = item.Genre;
        }

        Console.Write($"Publish Year({item.PublishYear}): ");
        string yearString = Console.ReadLine();
        int year = string.IsNullOrWhiteSpace(yearString) ? item.PublishYear : int.Parse(yearString); 

        Console.Write($"Total Copies({item.TotalCopies}): ");
        string total = Console.ReadLine();
        int totalCopies = string.IsNullOrWhiteSpace(total) ? item.TotalCopies : int.Parse(total);

        Console.Write($"Available Copies({item.AvailableCopies}): ");
        string available = Console.ReadLine();
        int availableCopies = string.IsNullOrWhiteSpace(available) ? item.AvailableCopies : int.Parse(available);

        item.UpdateInfo(title, author, genre, year, totalCopies, availableCopies);

        if(item is Book book)
        {
            Console.Write($"Pages ({book.Pages}): ");
            string pagesString = Console.ReadLine();
            int pages = string.IsNullOrWhiteSpace(pagesString) ? book.Pages : int.Parse(pagesString);

            Console.Write($"ISBN ({book.ISBN}): ");
            string isbn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbn))
            {
                isbn = book.ISBN;
            }

            book.UpdateBookInfo(pages, isbn);

            BookValidator validator = new BookValidator();
            ValidationResult result = validator.Validate(book);

            if (!ValidationHelper.PrintValidationResult(result))
            {
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Validation Error While Editing Book");
                return;
            }

            List<Book> books = JsonHelper.ReadBooks();
            int index = books.FindIndex(b => b.Id == id);

            books[index] = book;

            JsonHelper.WriteBooks(books);
        }
        else if(item is Magazine magazine)
        {
            Console.Write($"Issue Number ({magazine.IssueNumber}): ");
            string issueNumber= Console.ReadLine();
            if (string.IsNullOrWhiteSpace(issueNumber))
            {
                issueNumber = magazine.IssueNumber;
            }

            magazine.UpdateMagazineInfo(issueNumber);

            MagazineValidator validator = new MagazineValidator();
            ValidationResult result = validator.Validate(magazine);

            if (!ValidationHelper.PrintValidationResult(result))
            {
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Validation Error While Editing Magazine");
                return;
            }

            List<Magazine> magazines = JsonHelper.ReadMagazines();
            int index = magazines.FindIndex(m => m.Id == id);

            magazines[index] = magazine;

            JsonHelper.WriteMagazines(magazines);
        }
        else if(item is EBook eBook)
        {
            Console.Write($"File Format ({eBook.FileFormat}): ");
            string fileFormat = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileFormat))
            {
                fileFormat = eBook.FileFormat;
            }

            Console.Write($"File Size ({eBook.FileSizeMB}): ");
            string sizeString = Console.ReadLine();
            double size = string.IsNullOrWhiteSpace(sizeString) ? eBook.FileSizeMB : double.Parse(sizeString);

            eBook.UpdateEBookInfo(fileFormat, size);

            EBookValidator validator = new EBookValidator();
            ValidationResult result = validator.Validate(eBook);

            if (!ValidationHelper.PrintValidationResult(result))
            {
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Validation Error While Editing EBook");
                return;
            }

            List<EBook> eBooks = JsonHelper.ReadEBooks();
            int index = eBooks.FindIndex(e => e.Id == id);

            eBooks[index] = eBook;

            JsonHelper.WriteEBooks(eBooks);
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Edited Item: [{id}]");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Item Updated Successfully");
        Console.ResetColor();
    }

    public static void ViewUsers(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Users ***");
        Console.ForegroundColor = ConsoleColor.White;

        List<User> users = JsonHelper.ReadUsers();

        if (users.Count > 0)
        {
            foreach (User user in users)
            {
                Console.WriteLine(user);
            }
        }
        else
        {
            Console.WriteLine("No Users Found");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed All Users");

        Console.ResetColor();
    }

    public static void UserDetails(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter User ID/Full Name/Email: ");
        string credential = Console.ReadLine();

        List<User> users = JsonHelper.ReadUsers()
            .Where(u => u.Id == credential || u.FullName == credential || u.Email == credential).ToList();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Search Results For: {credential}");
        Console.ForegroundColor = ConsoleColor.White;

        if (users.Count == 0)
        {
            Console.WriteLine("No Users Found");
        }
        else if(users.Count == 1)
        {
            Console.WriteLine(users[0]);
        }
        else
        {
            foreach(User user in users)
            {
                Console.WriteLine(user);
                Console.WriteLine("----------");
            }
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed User Details For: '{credential}'");

        Console.ResetColor();
    }

    public static void TopReaders(string adminId)
    {
        List<User> users = JsonHelper.ReadUsers();
        List<BorrowRecord> records = JsonHelper.ReadRecords();

        List<User> tops = users.OrderByDescending(u => records.Count(r => r.UserId == u.Id)).ToList();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Top Readers ***");
        Console.ForegroundColor = ConsoleColor.White;

        foreach (User user in tops)
        {
            int count = records.Count(r => r.UserId == user.Id);
            Console.WriteLine($"ID: {user.Id}, Full Name: {user.FullName}, Email: {user.Email}, Items Borrowed: {count}");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed Top Readers");

        Console.ResetColor();
    }

    public static void OverdueBookReport(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Overdue Items ***");
        Console.ForegroundColor = ConsoleColor.White;

        foreach (User user in JsonHelper.ReadUsers())
        {
            List<BorrowRecord> overdueRecords = JsonHelper.ReadRecords().Where(r => r.UserId == user.Id && !r.IsReturned && r.IsOverdue()).ToList();
            
            if(overdueRecords.Count == 0)
            {
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"User ID: {user.Id}");
            Console.ForegroundColor = ConsoleColor.White;

            foreach(BorrowRecord record in overdueRecords)
            {
                Console.WriteLine($"    {record}");
            }

            Console.WriteLine();
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed Overdue Items Report");

        Console.ResetColor();
    }

    public static void ViewFines(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Fines ***");
        Console.ForegroundColor = ConsoleColor.White;

        foreach (User user in JsonHelper.ReadUsers())
        {
            Console.WriteLine($"User ID: {user.Id} -> {user.TotalFine():C}");
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed Fines");

        Console.ResetColor();
    }

    public static void SendReminders(string adminId)
    {
        string subject = "Book Return Reminder!";
        string body = "Dear reader!\n" +
            "We want to remind you that there are 2 days left until the book return date. " +
            "You will be fined 0.5$ for each overdue day.";

        foreach (User user in JsonHelper.ReadUsers())
        {
            foreach(BorrowRecord record in JsonHelper.ReadRecords())
            {
                if(record.UserId == user.Id && !record.IsReturned && (record.DueDate.Date - DateTime.Now.Date).Days == 2)
                {
                    EmailSender.SendEmail(user.Email, subject, body);
                }
            }
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Sent Reminder Emails");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Reminder Emails Sent Successfully");
        Console.ResetColor();
    }

    public static void LogHistory(string adminId)
    {
        string _logPath = @"D:\C#Projects\BookHub\BookHub\Logs\logs.txt";

        if (!File.Exists(_logPath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Something Went Wrong...");
            Console.ResetColor();

            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Failed To View Log History");

            return;
        }

        string[] lines = File.ReadAllLines(_logPath);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*** Log History ***");
        Console.ForegroundColor = ConsoleColor.White;

        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Viewed Log History");

        Console.ResetColor();
    }

    public static void AddNewAdmin(string adminId)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("ID: ");
        string id = Console.ReadLine();

        List<Admin> admins = JsonHelper.ReadAdmins();

        if (admins.Any(a => a.Id == id))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Admin With This ID Already Exists");
            Console.ResetColor();

            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Attempted To Add Dublicate Admin ID: [{id}]");

            return;
        }

        Console.Write("Full Name: ");
        string fullName = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        if (admins.Any(a => a.Email == email))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Admin With This Email Already Exists");
            Console.ResetColor();

            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Attempted To Add Dublicate Admin Email: [{email}]");

            return;
        }

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Phone Number: ");
        string number = Console.ReadLine();

        Console.Write("Department: ");
        string department = Console.ReadLine();

        Console.Write("Set Password: ");
        string password = Console.ReadLine();

        PasswordValidator validator = new PasswordValidator();
        ValidationResult result = validator.Validate(password);

        if (!ValidationHelper.PrintValidationResult(result))
        {
            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Validation Error While Adding New Admin");
            return;
        }

        string hashedPassword = PasswordHasher.Hash(password);

        Admin newAdmin = new Admin(id, fullName, email, address, number, hashedPassword, department);

        AdminValidator adminValidator = new AdminValidator();
        ValidationResult adminValidationResult = adminValidator.Validate(newAdmin);

        if (!ValidationHelper.PrintValidationResult(adminValidationResult))
        {
            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, $"Validation Error While Adding New Admin");
            return;
        }

        admins.Add(newAdmin);
        JsonHelper.WriteAdmins(admins);

        LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", adminId, $"Added New Admin: [{id}]");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("New Admin Added Successfully");
        Console.ResetColor();
    }

    public static void ChangePassword(Admin admin)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Current Password: ");
        string currentPassword = ConsoleHelper.HidePassword();

        if (admin.Verify(currentPassword))
        {
            Console.Write("Enter New Password: ");
            string newPassword = ConsoleHelper.HidePassword();

            PasswordValidator validator = new PasswordValidator();
            ValidationResult result = validator.Validate(newPassword);

            if (!ValidationHelper.PrintValidationResult(result))
            {
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", admin.Id, "Failed Password Change Attempt (New Password Did Not Meet Requirements)");
                return;
            }

            admin.SetPassword(newPassword);
            JsonHelper.UpdateAdmin(admin);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("Password Changed Successfully");

            LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", admin.Id, "Changed Their Password");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("Current Password Is Incorrect");

            LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", admin.Id, "Failed Password Change Attempt (Error: Incorrect Current Password)");
        }

        Console.ResetColor();
    }
}

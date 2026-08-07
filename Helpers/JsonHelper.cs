using System.Text.Json;
using BookHub.Models;
using BookHub.Models.Base;
using BookHub.Models.Derived;

namespace BookHub.Helpers;

public static class JsonHelper
{
    private static readonly string _booksPath = @"D:\C#Projects\BookHub\BookHub\Data\books.json";
    private static readonly string _magazinesPath = @"D:\C#Projects\BookHub\BookHub\Data\magazines.json";
    private static readonly string _eBooksPath = @"D:\C#Projects\BookHub\BookHub\Data\eBooks.json";
    private static readonly string _usersPath = @"D:\C#Projects\BookHub\BookHub\Data\users.json";
    private static readonly string _adminsPath = @"D:\C#Projects\BookHub\BookHub\Data\admins.json";
    private static readonly string _recordsPath = @"D:\C#Projects\BookHub\BookHub\Data\borrowRecords.json";
    
    public static List<LibraryItem> ReadData()
    {
        List<LibraryItem> data = new List<LibraryItem>();

        if (File.Exists(_booksPath))
        {
            data.AddRange(ReadBooks());
        }
        else
        {
            data.AddRange(new List<Book>());
        }

        if (File.Exists(_magazinesPath))
        {
            data.AddRange(ReadMagazines());
        }
        else
        {
            data.AddRange(new List<Magazine>());
        }

        if (File.Exists(_eBooksPath))
        {
            data.AddRange(ReadEBooks());
        }
        else
        {
            data.AddRange(new List<EBook>());
        }

        return data;
    }

    public static List<Book> ReadBooks()
    {
        if (!File.Exists(_booksPath))
        {
            return new List<Book>();
        }

        string booksContent = File.ReadAllText(_booksPath);
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(booksContent);
        return books;
    }

    public static List<Magazine> ReadMagazines()
    {
        if (!File.Exists(_magazinesPath))
        {
            return new List<Magazine>();
        }

        string magazinesContent = File.ReadAllText(_magazinesPath);
        List<Magazine> magazines = JsonSerializer.Deserialize<List<Magazine>>(magazinesContent);
        return magazines;
    }

    public static List<EBook> ReadEBooks()
    {
        if (!File.Exists(_eBooksPath))
        {
            return new List<EBook>();
        }

        string eBooksContent = File.ReadAllText(_eBooksPath);
        List<EBook> eBooks = JsonSerializer.Deserialize<List<EBook>>(eBooksContent);
        return eBooks;
    }

    public static void WriteBooks(List<Book> data)
    {
        File.WriteAllText(_booksPath, JsonSerializer.Serialize(data));
    }

    public static void WriteMagazines(List<Magazine> data)
    {
        File.WriteAllText(_magazinesPath, JsonSerializer.Serialize(data));
    }

    public static void WriteEBooks(List<EBook> data)
    {
        File.WriteAllText(_eBooksPath, JsonSerializer.Serialize(data));
    }

    public static List<User> ReadUsers()
    {
        if (!File.Exists(_usersPath))
        {
            return new List<User>();
        }

        string usersContent = File.ReadAllText(_usersPath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersContent);
        return users;
    }

    public static void WriteUsers(List<User> data)
    {
        File.WriteAllText(_usersPath, JsonSerializer.Serialize(data));
    }

    public static void UpdateUser(User user)
    {
        List<User> users = ReadUsers();
        int index = users.FindIndex(u => u.Id == user.Id);

        if(index >= 0)
        {
            users[index] = user;
        }

        WriteUsers(users);
    }

    public static List<Admin> ReadAdmins()
    {
        if (!File.Exists(_adminsPath))
        {
            return new List<Admin>();
        }

        string adminsContent = File.ReadAllText(_adminsPath);
        List<Admin> admins = JsonSerializer.Deserialize<List<Admin>>(adminsContent);
        return admins;
    }

    public static void WriteAdmins(List<Admin> data)
    {
        File.WriteAllText(_adminsPath, JsonSerializer.Serialize(data));
    }

    public static void UpdateAdmin(Admin admin)
    {
        List<Admin> admins = ReadAdmins();
        int index = admins.FindIndex(a => a.Id == admin.Id);

        if (index >= 0)
        {
            admins[index] = admin;
        }

        WriteAdmins(admins);
    }

    public static List<BorrowRecord> ReadRecords()
    {
        if (!File.Exists(_recordsPath))
        {
            return new List<BorrowRecord>();
        }

        string recordsContent = File.ReadAllText(_recordsPath);
        List<BorrowRecord> records = JsonSerializer.Deserialize<List<BorrowRecord>>(recordsContent);
        return records;
    }

    public static void WriteRecords(List<BorrowRecord> data)
    {
        File.WriteAllText(_recordsPath, JsonSerializer.Serialize(data));
    }
}

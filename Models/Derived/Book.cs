using BookHub.Models.Base;

namespace BookHub.Models.Derived;

public class Book : LibraryItem
{
    public int Pages { get; private set; }
    public string ISBN { get; private set; }

    public Book(string id, string title, string author, string genre, int publishYear, int totalCopies, int availableCopies, int pages, string isbn)
        : base(id, title, author, genre, publishYear, totalCopies, availableCopies)
    {
        Pages = pages;
        ISBN = isbn;
    }

    public static string GenerateId(List<Book> books)
    {
        if(books.Count == 0)
        {
            return "B00001";
        }

        int max = books.Select(b => int.Parse(b.Id.Substring(1))).Max();

        return $"B{(max + 1):D5}";
    }

    public override string ToString()
    {
        return base.ToString() + $", Pages: {Pages}, ISBN: {ISBN}";
    }

    public void UpdateBookInfo(int pages, string isbn)
    {
        Pages = pages;
        ISBN = isbn;
    }
}

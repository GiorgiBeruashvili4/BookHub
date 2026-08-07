
namespace BookHub.Models.Base;

public class LibraryItem
{
    public string Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }
    public int PublishYear { get; private set; }
    public int TotalCopies { get; private set; }
    public int AvailableCopies { get; private set; }

    public LibraryItem(string id, string title, string author, string genre, int publishYear, int totalCopies, int availableCopies)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
        PublishYear = publishYear;
        TotalCopies = totalCopies;
        AvailableCopies = availableCopies;
    }

    public bool Borrow()
    {
        if(AvailableCopies > 0)
        {
            AvailableCopies--;
            return true;
        }

        return false;
    }

    public void Return()
    {
        if(AvailableCopies < TotalCopies)
        {
            AvailableCopies++;
        }
    }

    public bool IsAvailable()
    {
        return AvailableCopies > 0;
    }

    public override string ToString()
    {
        return $"[{Id}] {Title} by {Author} ({PublishYear}) - Available: {AvailableCopies}";
    }

    public void UpdateInfo(string title, string author, string genre, int year, int total, int available)
    {
        Title = title;
        Author = author;
        Genre = genre;
        PublishYear = year;
        TotalCopies = total;
        AvailableCopies = available;
    }
}

using BookHub.Models.Base;

namespace BookHub.Models.Derived;

public class EBook : LibraryItem
{
    public string FileFormat { get; private set; }
    public double FileSizeMB { get; private set; }

    public EBook(string id, string title, string author, string genre, int publishYear, int totalCopies, int availableCopies, string fileFormat, double fileSizeMB)
        : base(id, title, author, genre, publishYear, totalCopies, availableCopies)
    {
        FileFormat = fileFormat;
        FileSizeMB = fileSizeMB;
    }

    public static string GenerateId(List<EBook> eBooks)
    {
        if (eBooks.Count == 0)
        {
            return "E00001";
        }

        int max = eBooks.Select(b => int.Parse(b.Id.Substring(1))).Max();

        return $"E{(max + 1):D5}";
    }

    public override string ToString()
    {
        return base.ToString() + $", Format: {FileFormat}, Size: {FileSizeMB}MB";
    }

    public void UpdateEBookInfo(string format, double size)
    {
        FileFormat = format;
        FileSizeMB = size;
    }
}

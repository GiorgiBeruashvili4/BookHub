using BookHub.Models.Base;

namespace BookHub.Models.Derived;

public class Magazine : LibraryItem
{
    public string IssueNumber { get; private set; }

    public Magazine(string id, string title, string author, string genre, int publishYear, int totalCopies, int availableCopies, string issueNumber) 
        : base(id, title, author, genre, publishYear, totalCopies, availableCopies)
    {
        IssueNumber = issueNumber;
    }

    public static string GenerateId(List<Magazine> magazines)
    {
        if (magazines.Count == 0)
        {
            return "M00001";
        }

        int max = magazines.Select(b => int.Parse(b.Id.Substring(1))).Max();

        return $"M{(max + 1):D5}";
    }

    public override string ToString()
    {
        return base.ToString() + $", Issue Number: #{IssueNumber}";
    }

    public void UpdateMagazineInfo(string number)
    {
        IssueNumber = number;
    }
}

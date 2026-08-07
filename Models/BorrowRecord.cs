using System.Text.Json.Serialization;

namespace BookHub.Models;

public class BorrowRecord
{
    public string Id { get; private set; }
    public string UserId { get; private set; }
    public string LibraryItemId { get; private set; }
    public DateTime BorrowDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime ReturnDate { get; private set; }
    public bool IsReturned { get; private set; }
    public decimal FineAmount { get; private set; }

    public BorrowRecord(string id, string userId, string libraryItemId, 
        DateTime borrowDate, DateTime dueDate, DateTime returnDate, 
        bool isReturned, decimal fineAmount)
    {
        Id = id;
        UserId = userId;
        LibraryItemId = libraryItemId;
        BorrowDate = borrowDate;
        DueDate = dueDate;
        ReturnDate = returnDate;
        IsReturned = isReturned;
        FineAmount = fineAmount;
    }

    public static BorrowRecord CreateRecord(string id, string userId, string libraryItemId)
    {
        DateTime borrowDate = DateTime.Now;
        return new BorrowRecord(id, userId, libraryItemId, borrowDate, 
            borrowDate.AddDays(14), DateTime.MinValue, false, 0);
    }

    public void MarkAsReturned()
    {
        ReturnDate = DateTime.Now;
        IsReturned = true;

        if (IsOverdue())
        {
            int overdueDays = (ReturnDate - DueDate).Days;
            FineAmount = overdueDays * 0.5m;
        }
    }

    public decimal GetFines()
    {
        if (IsReturned)
        {
            return FineAmount;
        }

        if (IsOverdue())
        {
            int overdueDays = (DateTime.Now - DueDate).Days;
            return overdueDays * 0.5m;
        }

        return 0;
    }

    public bool IsOverdue()
    {
        if (IsReturned)
        {
            return ReturnDate > DueDate;
        }
        else
        {
            return DateTime.Now > DueDate;
        }
    }

    public override string ToString()
    {
        string status;

        if (IsReturned)
        {
            status = "Returned";
        }
        else if(IsOverdue())
        {
            status = "Overdue";
        }
        else
        {
            status = "Active";
        }

        return $"Record ID: {Id}, Item ID: {LibraryItemId}, " +
            $"Borrow Date: {BorrowDate.ToString("yyyy-MM-dd")}, " +
            $"Due Date: {DueDate.Date.ToString("yyyy-MM-dd")}, " +
            $"Status: {status}, Fine: {GetFines()}$";
    }
}

using BookHub.Helpers;
using BookHub.Models.Base;

namespace BookHub.Models.Derived;

public class User : Person
{
    public User(string id, string fullName, string email, string address, string phoneNumber, string passwordHash) 
        : base(id, fullName, email, address, phoneNumber)
    {
        PasswordHash = passwordHash;
    }

    public decimal TotalFine()
    {
        decimal sum = 0;

        foreach(BorrowRecord record in JsonHelper.ReadRecords())
        {
            if(record.UserId == Id)
            {
                sum += record.FineAmount;
            }
        }
        return sum;
    }
}

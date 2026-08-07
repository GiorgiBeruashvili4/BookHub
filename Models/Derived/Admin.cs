using BookHub.Helpers;
using BookHub.Models.Base;

namespace BookHub.Models.Derived;

public class Admin : Person
{
    public string Department { get; private set; }

    public Admin(string id, string fullName, string email, string address, string phoneNumber, string passwordHash, string department) 
        : base(id, fullName, email, address, phoneNumber)
    {
        PasswordHash = passwordHash;
        Department = department;
    }
}

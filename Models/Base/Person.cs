using BookHub.Helpers;

namespace BookHub.Models.Base;

public class Person
{
    public string Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
    public string PhoneNumber { get; private set; }
    public string PasswordHash { get; set; }

    public Person(string id, string fullName, string email, string address, string phoneNumber)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    public Person()
    {
    }

    public void SetPassword(string password)
    {
        PasswordHash = PasswordHasher.Hash(password);
    }

    public bool Verify(string password)
    {
        return PasswordHasher.Verify(password, PasswordHash);
    }

    public override string ToString()
    {
        return $"ID: {Id}, " +
            $"Full Name: {FullName}, " +
            $"Email: {Email}, " +
            $"Address: {Address}, " +
            $"Phone Number: {PhoneNumber}";
    }
}

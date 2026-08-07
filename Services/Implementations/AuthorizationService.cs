using BookHub.Enums;
using BookHub.Helpers;
using BookHub.Models.Base;
using BookHub.Models.Derived;
using BookHub.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace BookHub.Services.Implementations;

public static class AuthorizationService
{
    public static Person Register()
    {
        Console.ForegroundColor = ConsoleColor.White;

        List<User> users = JsonHelper.ReadUsers();

        Console.Write("Enter ID: ");
        string id = Console.ReadLine();

        if (users.Any(u => u.Id == id))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Account With This ID Already Exists");
            Console.ResetColor();

            LoggingHelper.WriteLog(LogLevel.Warning, "User", "-----------", $"Registration Failed (Dublicate ID: [{id}])");

            return null;
        }

        Console.Write("Enter Full Name: ");
        string fullName = Console.ReadLine();

        Console.Write("Enter Address: ");
        string address = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        string number = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = ConsoleHelper.HidePassword();

        PasswordValidator validator = new PasswordValidator();
        ValidationResult result = validator.Validate(password);

        if (!ValidationHelper.PrintValidationResult(result))
        {
            LoggingHelper.WriteLog(LogLevel.Warning, "User", "-----------", "Registration Failed (Validation Error)");
            MenuHelper.Wait();
            return null;
        }

        string hashedPassword = PasswordHasher.Hash(password);

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        if(users.Any(u => u.Email == email))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Account With This Email Already Exists");
            Console.ResetColor();

            LoggingHelper.WriteLog(LogLevel.Warning, "User", "-----------", $"Registration Failed (Dublicate Email: [{email}])");

            return null;
        }

        EmailValidator emailValidator = new EmailValidator();
        ValidationResult emailValidationResult = emailValidator.Validate(email);

        if (!ValidationHelper.PrintValidationResult(emailValidationResult))
        {
            LoggingHelper.WriteLog(LogLevel.Warning, "User", "-----------", "Registration Failed (Validation Error)");
            MenuHelper.Wait();
            return null;
        }

        Random random = new Random();
        string code = random.Next(100000, 999999).ToString();
        EmailSender.SendEmail(email, "Verification Code", code);

        Console.Write("Enter 6-Digit Verification Code Sent To Your Email: ");
        string enteredCode = Console.ReadLine();

        if (enteredCode != code)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Verification Code. Registration Cancelled");
            Console.ResetColor();

            LoggingHelper.WriteLog(LogLevel.Warning, "User", "-----------", $"Registration Failed (Invalid Verification Code)");

            return null;
        }

        User newUser = new User(id, fullName, email, address, number, hashedPassword);

        UserValidator userValidator = new UserValidator();
        ValidationResult userValitationResult = userValidator.Validate(newUser);

        if (!ValidationHelper.PrintValidationResult(userValitationResult))
        {
            LoggingHelper.WriteLog(LogLevel.Warning, "User", "-----------", "Registration Failed (Validation Error)");
            MenuHelper.Wait();
            return null;
        }

        users.Add(newUser);
        JsonHelper.WriteUsers(users);

        LoggingHelper.WriteLog(LogLevel.Info, "User", newUser.Id, "Registered Successfully");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Registration Successful");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nDo You Want To Login Into Your Account (Y/N)? ");
        string answer = Console.ReadLine();

        if(answer.ToLower() == "n")
        {
            Console.Clear();
            Console.WriteLine("Bye");
            Console.ResetColor();
            return null;
        }

        Console.Clear();

        return Login();
    }
    
    public static Person Login()
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = ConsoleHelper.HidePassword();

        List<Person> people = new List<Person>();
        people.AddRange(JsonHelper.ReadUsers());
        people.AddRange(JsonHelper.ReadAdmins());

        Person person = people.FirstOrDefault(p => p.Email == email && p.Verify(password));

        if (person != null)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome Back, {person.FullName}\n");
            Console.ResetColor();

            if(person is User)
            {
                LoggingHelper.WriteLog(LogLevel.Info, "User", person.Id, "Logged In Successfully");
            }
            else
            {
                LoggingHelper.WriteLog(LogLevel.Info, "Admin", person.Id, "Logged In Successfully");
            }

            return person;
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong Credentials");
            Console.ResetColor();
            MenuHelper.Wait();

            LoggingHelper.WriteLog(LogLevel.Warning, "Null", "----------", $"Failed Login Attempt");

            return null;
        }
    }
}

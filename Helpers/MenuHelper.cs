namespace BookHub.Helpers;

public static class MenuHelper
{
    public static void Menu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("\n0. Exit");
        Console.ResetColor();
    }

    public static void ShowUserMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("***** Catalog *****");
        Console.WriteLine("1. Browse Catalog");
        Console.WriteLine("2. Search Catalog");
        Console.WriteLine("3. View Available Items");
        Console.WriteLine("4. Sort Catalog");
        Console.WriteLine("\n***** Borrowing *****");
        Console.WriteLine("5. Borrow Item");
        Console.WriteLine("6. Return Item");
        Console.WriteLine("7. Currently Borrowed Items");
        Console.WriteLine("8. Borrow History");
        Console.WriteLine("9. Overdue Books & Fines");
        Console.WriteLine("\n***** Account *****");
        Console.WriteLine("10. View Profile");
        Console.WriteLine("11. Change Password");
        Console.WriteLine("\n0. Logout");
        Console.ResetColor();
    }

    public static void ShowAdminMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Catalog Management");
        Console.WriteLine("2. User Management");
        Console.WriteLine("3. Reports");
        Console.WriteLine("4. System");
        Console.WriteLine("\n0. Logout");
        Console.ResetColor();
    }

    public static string Ask()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Choose An Option: ");
        string choice = Console.ReadLine();
        Console.ResetColor();

        return choice;
    }

    public static void Wait()
    {
        Console.Write("\nPress Any Key To Continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void ShowInvalidInput()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error. Invalid Input!");
        Console.ResetColor();
    }
}
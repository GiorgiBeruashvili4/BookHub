namespace BookHub.Helpers;

public static class SubmenuHelper
{
    public static void SearchSubmenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Search By Title");
        Console.WriteLine("2. Search By Author");
        Console.WriteLine("3. Search By Genre");
        Console.WriteLine("4. Search By Publish Year");
        Console.WriteLine("\n0. Back");
    }

    public static void SortSubmenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Sort By Title (A-Z)");
        Console.WriteLine("2. Sort By Title (Z-A)");
        Console.WriteLine("3. Sort By Publish Year (Oldest-Newest)");
        Console.WriteLine("4. Sort By Publish Year (Newest-Oldest)");
        Console.WriteLine("\n0. Back");
    }

    public static void CatalogManagement()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Add Magazine");
        Console.WriteLine("3. Add EBook");
        Console.WriteLine("4. Delete Item");
        Console.WriteLine("5. Edit Item");
        Console.WriteLine("6. View Catalog");
        Console.WriteLine("7. Filter Catalog");
        Console.WriteLine("\n0. Back");
        Console.ResetColor();
    }

    public static void FilterCatalog()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. By Title");
        Console.WriteLine("2. By Author");
        Console.WriteLine("3. By Genre");
        Console.WriteLine("4. By Publish Year");
        Console.WriteLine("5. Available Items");
        Console.WriteLine("6. Books Only");
        Console.WriteLine("7. Magazines Only");
        Console.WriteLine("8. EBooks Only");
        Console.WriteLine("\n0. Back");
        Console.ResetColor();
    }

    public static void UserManagement()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. View All Users");
        Console.WriteLine("2. View User Details");
        Console.WriteLine("\n0. Back");
        Console.ResetColor();
    }

    public static void Reports()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Overdue Item Report");
        Console.WriteLine("2. View Fines");
        Console.WriteLine("3. Top Readers");
        Console.WriteLine("\n0. Back");
        Console.ResetColor();
    }

    public static void System()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Send Reminder Emails");
        Console.WriteLine("2. View Log History");
        Console.WriteLine("3. Add New Admin");
        Console.WriteLine("4. Change Password");
        Console.WriteLine("\n0. Back");
        Console.ResetColor();
    }
}

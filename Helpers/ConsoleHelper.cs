namespace BookHub.Helpers;

public static class ConsoleHelper
{
    public static int ValidateInt(string s)
    {
        int result;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(s);

            if(int.TryParse(Console.ReadLine().Trim(), out result))
            {
                return result;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid Input");
            Console.ResetColor();
        }
    }

    public static string HidePassword()
    {
        string password = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if(key.Key == ConsoleKey.Enter)
            {
                break;
            }

            if(key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar))
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        }

        Console.WriteLine();
        return password;
    }
}

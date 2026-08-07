using BookHub.Enums;

namespace BookHub.Helpers;

public static class LoggingHelper
{
    private static readonly string _path = @"D:\C#Projects\BookHub\BookHub\Logs\logs.txt";

    public static void WriteLog(LogLevel level, string person, string id, string message)
    {
        using (StreamWriter sw = new StreamWriter(_path, true))
        {
            sw.WriteLine($"[{DateTime.Now}] [{level}] ({person}) with ID: [{id}] {message}");
        }
    }
}

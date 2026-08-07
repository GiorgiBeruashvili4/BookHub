using System.Text.Json;

namespace BookHub.Helpers;

public class SmtpHelper
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public static SmtpHelper LoadData()
    {
        string content = File.ReadAllText(@"D:\C#Projects\BookHub\BookHub\Config\smtp.json");

        return JsonSerializer.Deserialize<SmtpHelper>(content);
    }
}

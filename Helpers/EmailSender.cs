using System.Net;
using System.Net.Mail;

namespace BookHub.Helpers;

public static class EmailSender
{
    public static void SendEmail(string to, string subject, string body)
    {
        SmtpHelper smtpSettings = SmtpHelper.LoadData();

        SmtpClient smtp = new SmtpClient(smtpSettings.Host, smtpSettings.Port);
        smtp.UseDefaultCredentials = false;
        smtp.EnableSsl = true;

        smtp.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(smtpSettings.Username);
        mail.Subject = subject;
        mail.Body = body;
        mail.To.Add(to);

        smtp.Send(mail);
    }
}
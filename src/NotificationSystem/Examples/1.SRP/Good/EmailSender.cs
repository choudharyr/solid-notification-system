using System.Net.Mail;

namespace NotificationSystem.Examples.SRP.Good;

public class EmailSender
{
    private readonly SmtpClient _smtpClient;

    public EmailSender(string smtpServer = "smtp.server.com", int port = 587)  // Made SMTP settings optional with defaults
    {
        _smtpClient = new SmtpClient(smtpServer, port);
    }

    public void SendEmail(string recipient, string subject, string body)
    {
        _smtpClient.Send(new MailMessage("sender@example.com", recipient, subject, body));
    }
}
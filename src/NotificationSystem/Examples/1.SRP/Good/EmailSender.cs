using System.Net.Mail;

namespace NotificationSystem.Examples.SRP.Good;

public class EmailSender
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;

    public EmailSender(string smtpServer, int smtpPort)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
    }

    public void SendEmail(string recipient, string subject, string body)
    {
        using var client = new SmtpClient(_smtpServer, _smtpPort);
        client.Send(new MailMessage("notifications@example.com", recipient, subject, body));
    }
}

using NotificationSystem.Examples.DIP.Good.Interfaces;
using System.Net.Mail;

namespace NotificationSystem.Examples.DIP.Good.Services;

public class SmtpEmailClient : IEmailClient
{
    private readonly SmtpClient _smtpClient;

    public SmtpEmailClient(string smtpServer, int port)
    {
        _smtpClient = new SmtpClient(smtpServer, port);
    }

    public void SendEmail(string to, string subject, string message)
    {
        _smtpClient.Send(new MailMessage("from@example.com", to, subject, message));
    }
}
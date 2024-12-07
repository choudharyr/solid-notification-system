using NotificationSystem.Examples.DIP.Good.Interfaces;
using System.Net.Mail;

namespace NotificationSystem.Examples.DIP.Good.Services;

public class SmtpEmailClient : IEmailClient
{
    private readonly string _smtpServer;
    private readonly int _port;

    public SmtpEmailClient(string smtpServer, int port)
    {
        _smtpServer = smtpServer;
        _port = port;
    }

    public void SendEmail(string to, string subject, string message)
    {
        using var client = new SmtpClient(_smtpServer, _port);
        client.Send(new MailMessage("from@example.com", to, subject, message));
    }
}
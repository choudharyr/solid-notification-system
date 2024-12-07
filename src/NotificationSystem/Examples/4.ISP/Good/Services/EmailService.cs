using NotificationSystem.Examples.ISP.Good.Interfaces;

namespace NotificationSystem.Examples.ISP.Good.Services;

public class EmailService : IMessageSender
{
    public void SendMessage(string message, string recipient)
    {
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }
}

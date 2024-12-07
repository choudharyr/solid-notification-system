using NotificationSystem.Examples.OCP.Good.Interfaces;

namespace NotificationSystem.Examples.OCP.Good.Channels;

public class EmailChannel : INotificationChannel
{
    public string ChannelName => "Email";

    public void SendNotification(string message, string recipient)
    {
        // Email sending logic
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }
}
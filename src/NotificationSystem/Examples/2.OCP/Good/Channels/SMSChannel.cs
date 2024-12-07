using NotificationSystem.Examples.OCP.Good.Interfaces;

namespace NotificationSystem.Examples.OCP.Good.Channels;

public class SMSChannel : INotificationChannel
{
    public string ChannelName => "SMS";

    public void SendNotification(string message, string recipient)
    {
        // SMS sending logic
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
    }
}
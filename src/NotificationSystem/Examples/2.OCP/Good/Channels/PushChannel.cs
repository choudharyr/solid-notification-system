using NotificationSystem.Examples.OCP.Good.Interfaces;

namespace NotificationSystem.Examples.OCP.Good.Channels;

public class PushChannel : INotificationChannel
{
    public string ChannelName => "Push";

    public void SendNotification(string message, string recipient)
    {
        // SMS sending logic
        Console.WriteLine($"Sending Push to {recipient}: {message}");
    }
}
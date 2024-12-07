using NotificationSystem.Examples.OCP.Good.Interfaces;

namespace NotificationSystem.Examples.OCP.Good.Channels;

// Adding a new channel without modifying existing code
public class TeamsChannel : INotificationChannel
{
    public string ChannelName => "Teams";

    public void SendNotification(string message, string recipient)
    {
        // Teams message sending logic
        Console.WriteLine($"Sending Teams message to {recipient}: {message}");
    }
}
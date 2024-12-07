using NotificationSystem.Examples.OCP.Good.Interfaces;

public class SlackChannel : INotificationChannel
{
    public string ChannelName => "Slack";

    public void SendNotification(string message, string recipient)
    {
        // Slack message sending logic
        Console.WriteLine($"Sending Slack message to {recipient}: {message}");
    }
}
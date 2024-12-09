using NotificationSystem.Examples.OCP.Good.Interfaces;

public class SmsChannel : INotificationChannel
{
    public string ChannelName => "SMS";

    public void SendNotification(string message, string recipient)
    {
        // Slack message sending logic
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
    }
}
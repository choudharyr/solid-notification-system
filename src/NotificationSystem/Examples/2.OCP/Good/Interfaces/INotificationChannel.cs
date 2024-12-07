namespace NotificationSystem.Examples.OCP.Good.Interfaces;

public interface INotificationChannel
{
    string ChannelName { get; }
    void SendNotification(string message, string recipient);
}
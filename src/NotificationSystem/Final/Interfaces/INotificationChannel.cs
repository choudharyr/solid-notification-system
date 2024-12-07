using NotificationSystem.Final.Models;

namespace NotificationSystem.Final.Interfaces;

public interface INotificationChannel
{
    string ChannelType { get; }
    Task<bool> SendAsync(NotificationMessage message);
}
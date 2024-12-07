using NotificationSystem.Final.Models;

namespace NotificationSystem.Final.Interfaces;

public interface INotificationLogger
{
    Task LogAsync(NotificationMessage message, string status, string? error = null);
}
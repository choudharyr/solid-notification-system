using NotificationSystem.Final.Models;

namespace NotificationSystem.Final.Interfaces;

public interface INotificationFormatter
{
    string FormatMessage(NotificationMessage message);
}
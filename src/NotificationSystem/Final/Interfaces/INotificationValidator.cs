using NotificationSystem.Final.Models;

namespace NotificationSystem.Final.Interfaces;

public interface INotificationValidator
{
    ValidationResult Validate(NotificationMessage message);
}
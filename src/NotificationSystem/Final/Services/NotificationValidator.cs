using NotificationSystem.Final.Interfaces;
using NotificationSystem.Final.Models;

namespace NotificationSystem.Final.Services;

public class NotificationValidator : INotificationValidator
{
    public ValidationResult Validate(NotificationMessage message)
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(message.Content)) {
            errors.Add("Message content cannot be empty");
        }

        if (string.IsNullOrEmpty(message.Recipient)) {
            errors.Add("Recipient cannot be empty");
        }

        // Channel-specific validation
        switch (message.ChannelType.ToLower()) {
            case "email" when !message.Recipient.Contains("@"):
                errors.Add("Invalid email address");
                break;

            case "sms" when !message.Recipient.All(char.IsDigit):
                errors.Add("Invalid phone number");
                break;
        }

        return errors.Any()
            ? ValidationResult.Failure(errors)
            : ValidationResult.Success();
    }
}
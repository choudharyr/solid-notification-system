namespace NotificationSystem.Examples.OCP.Bad;

/// <summary>
/// This example demonstrates a violation of the Open-Closed Principle.
/// The class has to be modified every time a new notification type needs to be added,
/// making it not closed for modification.
/// </summary>
public class NotificationService
{
    // This class violates OCP because adding a new notification type
    // requires modifying the existing code
    public void SendNotification(string message, string recipient, string notificationType)
    {
        switch (notificationType.ToLower()) {
            case "email":
                SendEmail(message, recipient);
                break;

            case "sms":
                SendSMS(message, recipient);
                break;

            case "slack":
                SendSlackMessage(message, recipient);
                break;

            default:
                throw new ArgumentException($"Unsupported notification type: {notificationType}");
        }
    }

    private void SendEmail(string message, string recipient)
    {
        // Email sending logic
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }

    private void SendSMS(string message, string recipient)
    {
        // SMS sending logic
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
    }

    private void SendSlackMessage(string message, string recipient)
    {
        // Slack message sending logic
        Console.WriteLine($"Sending Slack message to {recipient}: {message}");
    }
}
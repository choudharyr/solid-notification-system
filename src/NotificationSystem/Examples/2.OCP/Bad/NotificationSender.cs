namespace NotificationSystem.Examples.OCP.Bad;

/// <summary>
/// This example demonstrates a violation of the Open-Closed Principle.
/// The class has to be modified every time a new notification type needs to be added,
/// making it not closed for modification.
/// </summary>
public class NotificationSender
{
    public void Send(string message, string recipient, string type)
    {
        switch (type) {
            case "email":
                // Send email
                break;
            case "sms":
                // Send SMS
                break;
            case "push":
                // Send push notification
                break;
        }
    }
}
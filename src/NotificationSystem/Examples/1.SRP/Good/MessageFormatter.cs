namespace NotificationSystem.Examples.SRP.Good;

public class MessageFormatter
{
    public string FormatMessage(string message)
    {
        return $"""
                [Notification sent on {DateTime.Now}]

                {message}

                Best regards,
                Notification System
                """;
    }
}
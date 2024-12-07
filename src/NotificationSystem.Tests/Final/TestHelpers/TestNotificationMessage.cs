using NotificationSystem.Final.Models;

namespace NotificationSystem.Tests.Final.TestHelpers;

public static class TestNotificationMessage
{
    public static NotificationMessage CreateValidEmailMessage()
    {
        return new NotificationMessage(
            "test@example.com",
            "Test message",
            "Email",
            new Dictionary<string, string> { { "subject", "Test Subject" } }
        );
    }

    public static NotificationMessage CreateValidSmsMessage()
    {
        return new NotificationMessage(
            "1234567890",
            "Test message",
            "SMS"
        );
    }
}
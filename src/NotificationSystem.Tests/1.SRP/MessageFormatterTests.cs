using NotificationSystem.Examples.SRP.Good;

namespace NotificationSystem.Tests.SRP;

public class MessageFormatterTests
{
    private readonly MessageFormatter _formatter;

    public MessageFormatterTests()
    {
        _formatter = new MessageFormatter();
    }

    [Fact]
    public void FormatMessage_AddsDateAndSignature()
    {
        // Arrange
        var message = "Test message";

        // Act
        var formattedMessage = _formatter.FormatMessage(message);

        // Assert
        Assert.Contains("[Notification sent on", formattedMessage);
        Assert.Contains(message, formattedMessage);
        Assert.Contains("Best regards", formattedMessage);
        Assert.Contains("Notification System", formattedMessage);
    }
}
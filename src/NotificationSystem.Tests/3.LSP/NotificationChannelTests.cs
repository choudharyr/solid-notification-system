using NotificationSystem.Examples.LSP.Good;

namespace NotificationSystem.Tests.LSP;

public class NotificationChannelTests
{
    [Fact]
    public void BaseClass_CanBeSubstitutedWithEmailChannel()
    {
        // Arrange
        NotificationChannel channel = new EmailChannel();
        var message = "Test message";
        var recipient = "test@example.com";

        // Act
        var result = channel.SendMessage(message, recipient);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void BaseClass_CanBeSubstitutedWithSMSChannel()
    {
        // Arrange
        NotificationChannel channel = new SMSChannel();
        var message = "Test message";
        var recipient = "1234567890";

        // Act
        var result = channel.SendMessage(message, recipient);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("", "test@example.com")] // Empty message
    [InlineData("Test", "invalid-email")] // Invalid email
    public void EmailChannel_WithInvalidInput_ReturnsFalse(string message, string recipient)
    {
        // Arrange
        var channel = new EmailChannel();

        // Act
        var result = channel.SendMessage(message, recipient);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("Very long message that exceeds 160 characters limit...", "1234567890")] // Long message
    [InlineData("Test", "abc123")] // Invalid phone number
    public void SMSChannel_WithInvalidInput_ReturnsFalse(string message, string recipient)
    {
        // Arrange
        var channel = new SMSChannel();

        // Act
        var result = channel.SendMessage(message, recipient);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotificationService_WorksWithAnyChannel()
    {
        // Arrange
        var channels = new List<NotificationChannel>
        {
            new EmailChannel(),
            new SMSChannel()
        };
        var service = new NotificationService(channels);

        // Act & Assert
        Assert.True(service.SendMessage("Test", "test@example.com")); // Will succeed via email
        Assert.True(service.SendMessage("Test", "1234567890")); // Will succeed via SMS
        Assert.False(service.SendMessage("Test", "invalid")); // Will fail both
    }
}
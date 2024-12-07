using NotificationSystem.Examples.OCP.Good;
using NotificationSystem.Examples.OCP.Good.Channels;
using NotificationSystem.Examples.OCP.Good.Interfaces;

namespace NotificationSystem.Tests.OCP;
public class NotificationServiceTests
{
    private readonly List<INotificationChannel> _channels;
    private readonly NotificationService _service;

    public NotificationServiceTests()
    {
        _channels = new List<INotificationChannel>
        {
            new EmailChannel(),
            new SMSChannel(),
            new SlackChannel()
        };
        _service = new NotificationService(_channels);
    }

    [Theory]
    [InlineData("Email")]
    [InlineData("SMS")]
    [InlineData("Slack")]
    public void SendNotification_WithSupportedChannel_SendsNotification(string channelName)
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";

        // Act & Assert
        var exception = Record.Exception(() =>
            _service.SendNotification(message, recipient, channelName));
        Assert.Null(exception);
    }

    [Fact]
    public void SendNotification_WithUnsupportedChannel_ThrowsException()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var channelName = "UnsupportedChannel";

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            _service.SendNotification(message, recipient, channelName));
    }

    [Fact]
    public void AddingNewChannel_DoesNotRequireChangingExistingCode()
    {
        // Arrange
        var channels = new List<INotificationChannel>
        {
            new EmailChannel(),
            new TeamsChannel()  // Adding new channel
        };
        var service = new NotificationService(channels);
        var message = "Test message";
        var recipient = "test@example.com";

        // Act & Assert
        var exception = Record.Exception(() =>
            service.SendNotification(message, recipient, "Teams"));
        Assert.Null(exception);
    }
}
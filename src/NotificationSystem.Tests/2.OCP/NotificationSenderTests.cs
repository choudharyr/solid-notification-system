using NotificationSystem.Examples.OCP.Good;
using NotificationSystem.Examples.OCP.Good.Channels;
using NotificationSystem.Examples.OCP.Good.Interfaces;

namespace NotificationSystem.Tests.OCP;
public class NotificationSenderTests
{
    [Fact]
    public void Send_WithValidChannel_SendsNotification()
    {
        // Arrange
        var channels = new List<INotificationChannel>
        {
            new EmailChannel(),
            new SmsChannel(),
            new PushChannel()
        };
        var sender = new NotificationSender(channels);

        // Act
        var exception = Record.Exception(() =>
            sender.SendNotification("Test message", "recipient", "email"));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Send_WithInvalidChannel_ThrowsException()
    {
        // Arrange
        var channels = new List<INotificationChannel>
        {
            new EmailChannel(),
            new SmsChannel()
        };
        var sender = new NotificationSender(channels);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            sender.SendNotification("Test message", "recipient", "invalidchannel"));
    }
}
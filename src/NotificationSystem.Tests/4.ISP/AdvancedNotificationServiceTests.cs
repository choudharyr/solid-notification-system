using NotificationSystem.Examples.ISP.Good.Interfaces;
using NotificationSystem.Examples.ISP.Good.Services;

namespace NotificationSystem.Tests.ISP;

public class AdvancedNotificationServiceTests
{
    private readonly AdvancedNotificationService _service;

    public AdvancedNotificationServiceTests()
    {
        _service = new AdvancedNotificationService();
    }

    [Fact]
    public void ImplementsRequiredInterfaces()
    {
        // Assert
        Assert.True(_service is IMessageSender);
        Assert.True(_service is IMessageScheduler);
        Assert.True(_service is IMessageTracker);
        Assert.False(_service is IMessageStorage); // Shouldn't implement this
        Assert.False(_service is IReportGenerator); // Shouldn't implement this
    }

    [Fact]
    public void SendMessage_ExecutesWithoutException()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";

        // Act
        var exception = Record.Exception(() =>
            _service.SendMessage(message, recipient));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ScheduleMessage_ExecutesWithoutException()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var scheduleTime = DateTime.Now.AddHours(1);

        // Act
        var exception = Record.Exception(() =>
            _service.ScheduleMessage(message, recipient, scheduleTime));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void CancelScheduledMessage_ExecutesWithoutException()
    {
        // Arrange
        var messageId = "test-id";

        // Act
        var exception = Record.Exception(() =>
            _service.CancelScheduledMessage(messageId));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void TrackDeliveryStatus_ExecutesWithoutException()
    {
        // Act
        var exception = Record.Exception(() =>
            _service.TrackDeliveryStatus());

        // Assert
        Assert.Null(exception);
    }
}
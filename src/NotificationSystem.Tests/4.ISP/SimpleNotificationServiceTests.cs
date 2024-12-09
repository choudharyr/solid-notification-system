using NotificationSystem.Examples.ISP.Good.Interfaces;
using NotificationSystem.Examples.ISP.Good.Services;

namespace NotificationSystem.Tests.ISP;

public class SimpleNotificationServiceTests
{
    private readonly SimpleNotificationService _service;

    public SimpleNotificationServiceTests()
    {
        _service = new SimpleNotificationService();
    }

    [Fact]
    public void CanBeUsedAsMessageSender()
    {
        // Arrange
        IMessageSender sender = _service;

        // Act & Assert
        Assert.NotNull(sender);
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
}
using Moq;
using NotificationSystem.Final;
using NotificationSystem.Final.Interfaces;
using NotificationSystem.Final.Models;
using NotificationSystem.Tests.Final.TestHelpers;

namespace NotificationSystem.Tests.Final;

public class NotificationServiceTests
{
    private readonly Mock<INotificationChannel> _mockEmailChannel;
    private readonly Mock<INotificationChannel> _mockSmsChannel;
    private readonly Mock<INotificationValidator> _mockValidator;
    private readonly Mock<INotificationLogger> _mockLogger;
    private readonly NotificationService _service;

    public NotificationServiceTests()
    {
        _mockEmailChannel = new Mock<INotificationChannel>();
        _mockEmailChannel.Setup(c => c.ChannelType).Returns("Email");

        _mockSmsChannel = new Mock<INotificationChannel>();
        _mockSmsChannel.Setup(c => c.ChannelType).Returns("SMS");

        _mockValidator = new Mock<INotificationValidator>();
        _mockLogger = new Mock<INotificationLogger>();

        _service = new NotificationService(
            new[] { _mockEmailChannel.Object, _mockSmsChannel.Object },
            _mockValidator.Object,
            _mockLogger.Object
        );
    }

    [Fact]
    public async Task SendNotificationAsync_WithValidEmailMessage_SendsViaEmailChannel()
    {
        // Arrange
        var message = TestNotificationMessage.CreateValidEmailMessage();
        _mockValidator.Setup(v => v.Validate(message))
            .Returns(ValidationResult.Success());
        _mockEmailChannel.Setup(c => c.SendAsync(message))
            .ReturnsAsync(true);

        // Act
        var result = await _service.SendNotificationAsync(message);

        // Assert
        Assert.True(result);
        _mockEmailChannel.Verify(c => c.SendAsync(message), Times.Once);
        _mockSmsChannel.Verify(c => c.SendAsync(message), Times.Never);
        await VerifySuccessLogged(message);
    }

    [Fact]
    public async Task SendNotificationAsync_WithInvalidMessage_DoesNotSend()
    {
        // Arrange
        var message = TestNotificationMessage.CreateValidEmailMessage();
        var errors = new List<string> { "Invalid message" };
        _mockValidator.Setup(v => v.Validate(message))
            .Returns(ValidationResult.Failure(errors));

        // Act
        var result = await _service.SendNotificationAsync(message);

        // Assert
        Assert.False(result);
        _mockEmailChannel.Verify(c => c.SendAsync(message), Times.Never);
        _mockSmsChannel.Verify(c => c.SendAsync(message), Times.Never);
        await VerifyValidationFailureLogged(message, errors);
    }

    [Fact]
    public async Task SendNotificationAsync_WithUnsupportedChannel_DoesNotSend()
    {
        // Arrange
        var message = new NotificationMessage(
            "test@example.com",
            "Test message",
            "UnsupportedChannel"
        );
        _mockValidator.Setup(v => v.Validate(message))
            .Returns(ValidationResult.Success());

        // Act
        var result = await _service.SendNotificationAsync(message);

        // Assert
        Assert.False(result);
        _mockEmailChannel.Verify(c => c.SendAsync(message), Times.Never);
        _mockSmsChannel.Verify(c => c.SendAsync(message), Times.Never);
        await VerifyUnsupportedChannelLogged(message);
    }

    [Fact]
    public async Task SendNotificationAsync_WhenChannelFails_ReturnsFalse()
    {
        // Arrange
        var message = TestNotificationMessage.CreateValidEmailMessage();
        _mockValidator.Setup(v => v.Validate(message))
            .Returns(ValidationResult.Success());
        _mockEmailChannel.Setup(c => c.SendAsync(message))
            .ReturnsAsync(false);

        // Act
        var result = await _service.SendNotificationAsync(message);

        // Assert
        Assert.False(result);
        await VerifyFailureLogged(message);
    }

    private async Task VerifySuccessLogged(NotificationMessage message)
    {
        _mockLogger.Verify(l =>
            l.LogAsync(message, "Sent", null), Times.Once);
    }

    private async Task VerifyFailureLogged(NotificationMessage message)
    {
        _mockLogger.Verify(l =>
            l.LogAsync(message, "Failed", null), Times.Once);
    }

    private async Task VerifyValidationFailureLogged(NotificationMessage message, List<string> errors)
    {
        _mockLogger.Verify(l =>
            l.LogAsync(message, "Validation Failed", It.Is<string>(s =>
                errors.All(e => s.Contains(e)))), Times.Once);
    }

    private async Task VerifyUnsupportedChannelLogged(NotificationMessage message)
    {
        _mockLogger.Verify(l =>
            l.LogAsync(message, "Failed", "Unsupported channel type"), Times.Once);
    }
}

using Moq;
using NotificationSystem.Examples.SRP.Good;
using NotificationSystem.Examples.SRP.Good.Models;

namespace NotificationSystem.Tests.SRP;

public class NotificationServiceTests
{
    private readonly Mock<MessageValidator> _mockValidator;
    private readonly Mock<MessageFormatter> _mockFormatter;
    private readonly Mock<NotificationLogger> _mockLogger;
    private readonly Mock<UserPreferenceManager> _mockPreferenceManager;
    private readonly Mock<EmailSender> _mockEmailSender;
    private readonly NotificationService _service;

    public NotificationServiceTests()
    {
        _mockValidator = new Mock<MessageValidator>();
        _mockFormatter = new Mock<MessageFormatter>();
        _mockLogger = new Mock<NotificationLogger>("test.log");
        _mockPreferenceManager = new Mock<UserPreferenceManager>();
        _mockEmailSender = new Mock<EmailSender>("smtp.test.com", 587);

        _service = new NotificationService(
            _mockValidator.Object,
            _mockFormatter.Object,
            _mockLogger.Object,
            _mockPreferenceManager.Object,
            _mockEmailSender.Object
        );
    }

    [Fact]
    public void SendNotification_WhenUserHasDisabledNotifications_DoesNotSendEmail()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var preferences = new UserPreferences { EmailNotificationsEnabled = false };

        _mockPreferenceManager
            .Setup(x => x.GetUserPreferences(recipient))
            .Returns(preferences);

        // Act
        _service.SendNotification(message, recipient);

        // Assert
        _mockEmailSender.Verify(
            x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never
        );
        _mockLogger.Verify(
            x => x.LogMessage(It.Is<string>(msg => msg.Contains("disabled email notifications"))),
            Times.Once
        );
    }

    [Fact]
    public void SendNotification_WhenUserHasEnabledNotifications_SendsEmail()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var formattedMessage = "Formatted message";
        var preferences = new UserPreferences { EmailNotificationsEnabled = true };

        _mockPreferenceManager
            .Setup(x => x.GetUserPreferences(recipient))
            .Returns(preferences);
        _mockFormatter
            .Setup(x => x.FormatMessage(message))
            .Returns(formattedMessage);

        // Act
        _service.SendNotification(message, recipient);

        // Assert
        _mockEmailSender.Verify(
            x => x.SendEmail(recipient, "New Notification", formattedMessage),
            Times.Once
        );
        _mockLogger.Verify(
            x => x.LogMessage(It.Is<string>(msg => msg.Contains("successfully"))),
            Times.Once
        );
    }

    [Fact]
    public void SendNotification_WhenExceptionOccurs_LogsErrorAndRethrows()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var preferences = new UserPreferences { EmailNotificationsEnabled = true };
        var expectedException = new Exception("Test exception");

        _mockPreferenceManager
            .Setup(x => x.GetUserPreferences(recipient))
            .Returns(preferences);
        _mockEmailSender
            .Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Throws(expectedException);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _service.SendNotification(message, recipient));
        Assert.Same(expectedException, exception);
        _mockLogger.Verify(
            x => x.LogMessage(It.Is<string>(msg => msg.Contains("Error") && msg.Contains(expectedException.Message))),
            Times.Once
        );
    }
}
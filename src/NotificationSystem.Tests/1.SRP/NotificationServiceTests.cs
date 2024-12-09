using Moq;
using NotificationSystem.Examples.SRP.Good;

namespace NotificationSystem.Tests.SRP;

public class NotificationServiceTests
{
    private readonly Mock<NotificationFormatter> _mockFormatter;
    private readonly Mock<NotificationLogger> _mockLogger;
    private readonly Mock<EmailSender> _mockEmailSender;
    private readonly Mock<NotificationRepository> _mockRepository;
    private readonly NotificationService _service;

    public NotificationServiceTests()
    {
        _mockFormatter = new Mock<NotificationFormatter>();
        _mockLogger = new Mock<NotificationLogger>();
        _mockEmailSender = new Mock<EmailSender>();
        _mockRepository = new Mock<NotificationRepository>();

        _service = new NotificationService(
            _mockFormatter.Object,
            _mockLogger.Object,
            _mockEmailSender.Object,
            _mockRepository.Object
        );
    }

    [Fact]
    public void SendNotification_ShouldCoordinateAllOperations()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var formattedMessage = "[Formatted] Test message";

        _mockFormatter
            .Setup(f => f.FormatMessage(message))
            .Returns(formattedMessage);

        // Act
        _service.SendNotification(message, recipient);

        // Assert
        _mockFormatter.Verify(f => f.FormatMessage(message), Times.Once);
        _mockLogger.Verify(l => l.LogMessage(recipient, message), Times.Once);
        _mockEmailSender.Verify(e => e.SendEmail(recipient, "Notification", formattedMessage), Times.Once);
        _mockRepository.Verify(r => r.Store(recipient, message), Times.Once);
    }

    [Fact]
    public void SendNotification_WhenErrorOccurs_ShouldLogAndRethrow()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var expectedException = new Exception("Test exception");

        _mockEmailSender
            .Setup(e => e.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Throws(expectedException);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() =>
            _service.SendNotification(message, recipient));

        Assert.Same(expectedException, exception);
        _mockLogger.Verify(l =>
            l.LogMessage(recipient, It.Is<string>(s => s.Contains("Error"))), Times.Once);
    }
}
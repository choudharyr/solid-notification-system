using Moq;
using NotificationSystem.Examples.DIP.Good;
using NotificationSystem.Examples.DIP.Good.Interfaces;

namespace NotificationSystem.Tests.DIP;

public class EmailServiceTests
{
    private readonly Mock<IEmailClient> _mockEmailClient;
    private readonly Mock<IEmailLogger> _mockEmailLogger;
    private readonly EmailService _emailService;

    public EmailServiceTests()
    {
        _mockEmailClient = new Mock<IEmailClient>();
        _mockEmailLogger = new Mock<IEmailLogger>();
        _emailService = new EmailService(_mockEmailClient.Object, _mockEmailLogger.Object);
    }

    [Fact]
    public void Constructor_WithNullEmailClient_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new EmailService(null!, _mockEmailLogger.Object));
    }

    [Fact]
    public void Constructor_WithNullEmailLogger_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new EmailService(_mockEmailClient.Object, null!));
    }

    [Fact]
    public void SendEmail_CallsEmailClientAndLogger()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";

        // Act
        _emailService.SendEmail(message, recipient);

        // Assert
        _mockEmailClient.Verify(c =>
            c.SendEmail(recipient, "Notification", message), Times.Once);
        _mockEmailLogger.Verify(l =>
            l.LogEmail(message, recipient), Times.Once);
    }

    [Fact]
    public void SendEmail_WhenEmailClientThrows_PropagatesException()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var expectedException = new Exception("Test exception");

        _mockEmailClient
            .Setup(c => c.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Throws(expectedException);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() =>
            _emailService.SendEmail(message, recipient));

        Assert.Same(expectedException, exception);
    }

    [Fact]
    public void SendEmail_WhenLoggerThrows_PropagatesException()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";
        var expectedException = new Exception("Test exception");

        _mockEmailLogger
            .Setup(l => l.LogEmail(It.IsAny<string>(), It.IsAny<string>()))
            .Throws(expectedException);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() =>
            _emailService.SendEmail(message, recipient));

        Assert.Same(expectedException, exception);
    }
}
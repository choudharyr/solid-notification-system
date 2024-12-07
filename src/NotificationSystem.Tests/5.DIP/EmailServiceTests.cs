using Moq;
using NotificationSystem.Examples.DIP.Good;
using NotificationSystem.Examples.DIP.Good.Interfaces;

namespace NotificationSystem.Tests.DIP;

public class EmailServiceTests
{
    private readonly Mock<IEmailClient> _mockEmailClient;
    private readonly Mock<IEmailRepository> _mockRepository;
    private readonly Mock<IEmailLogger> _mockLogger;
    private readonly EmailService _emailService;

    public EmailServiceTests()
    {
        _mockEmailClient = new Mock<IEmailClient>();
        _mockRepository = new Mock<IEmailRepository>();
        _mockLogger = new Mock<IEmailLogger>();

        _emailService = new EmailService(
            _mockEmailClient.Object,
            _mockRepository.Object,
            _mockLogger.Object);
    }

    [Fact]
    public void SendEmail_Success_LogsAndSavesEmail()
    {
        // Arrange
        var to = "test@example.com";
        var message = "Test message";

        // Act
        _emailService.SendEmail(to, message);

        // Assert
        _mockEmailClient.Verify(x =>
            x.SendEmail(to, "Notification", message), Times.Once);

        _mockRepository.Verify(x =>
            x.SaveEmailLog(to, message, It.IsAny<DateTime>()), Times.Once);

        _mockLogger.Verify(x =>
            x.Log(It.Is<string>(s => s.Contains("sent"))), Times.Once);
    }

    [Fact]
    public void SendEmail_WhenErrorOccurs_LogsErrorAndRethrows()
    {
        // Arrange
        var to = "test@example.com";
        var message = "Test message";
        var expectedException = new Exception("Test exception");

        _mockEmailClient
            .Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Throws(expectedException);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => _emailService.SendEmail(to, message));
        Assert.Same(expectedException, exception);

        _mockLogger.Verify(x =>
            x.Log(It.Is<string>(s => s.Contains("Error"))), Times.Once);
    }
}
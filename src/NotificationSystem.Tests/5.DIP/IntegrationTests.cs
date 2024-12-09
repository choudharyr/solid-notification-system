using Moq;
using NotificationSystem.Examples.DIP.Good;
using NotificationSystem.Examples.DIP.Good.Interfaces;
using NotificationSystem.Examples.DIP.Good.Services;

namespace NotificationSystem.Tests.DIP;

public class IntegrationTests
{
    [Fact]
    public void CanCreateConcreteImplementations()
    {
        // Arrange
        IEmailClient emailClient = new SmtpEmailClient("smtp.test.com", 587);
        IEmailLogger emailLogger = new SqlEmailLogger("test-connection-string");

        // Act
        var emailService = new EmailService(emailClient, emailLogger);

        // Assert
        Assert.NotNull(emailService);
    }

    [Fact]
    public void CanUseDifferentImplementations()
    {
        // Arrange
        var mockEmailClient = new Mock<IEmailClient>();
        var mockEmailLogger = new Mock<IEmailLogger>();
        var emailService = new EmailService(mockEmailClient.Object, mockEmailLogger.Object);

        var message = "Test message";
        var recipient = "test@example.com";

        // Act
        emailService.SendEmail(message, recipient);

        // Assert
        mockEmailClient.Verify(c =>
            c.SendEmail(recipient, "Notification", message), Times.Once);
        mockEmailLogger.Verify(l =>
            l.LogEmail(message, recipient), Times.Once);
    }
}
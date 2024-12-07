using NotificationSystem.Examples.ISP.Good.Interfaces;
using NotificationSystem.Examples.ISP.Good.Services;

namespace NotificationSystem.Tests.ISP;

public class EmailServiceTests
{
    [Fact]
    public void SimpleEmailService_OnlyRequiresMessageSending()
    {
        // Arrange
        IMessageSender emailService = new EmailService();

        // Act & Assert
        // Only needs to implement SendMessage
        var exception = Record.Exception(() =>
            emailService.SendMessage("Test", "test@example.com"));
        Assert.Null(exception);
    }

    [Fact]
    public void AdvancedEmailService_SupportsValidationAndEncryption()
    {
        // Arrange
        var emailService = new AdvancedEmailService();

        // Act & Assert
        // Can be used as any of its interfaces
        IMessageSender sender = emailService;
        IMessageValidator validator = emailService;
        IMessageEncryption encryption = emailService;

        Assert.NotNull(sender);
        Assert.NotNull(validator);
        Assert.NotNull(encryption);
    }

    [Fact]
    public void EnterpriseEmailService_SupportsAllFeatures()
    {
        // Arrange
        var emailService = new EnterpriseEmailService();

        // Act & Assert
        // Can be used as any of its interfaces
        IMessageSender sender = emailService;
        IMessageScheduler scheduler = emailService;
        IMessageTracker tracker = emailService;
        IMessageStore store = emailService;
        IReportGenerator reporter = emailService;

        Assert.NotNull(sender);
        Assert.NotNull(scheduler);
        Assert.NotNull(tracker);
        Assert.NotNull(store);
        Assert.NotNull(reporter);
    }
}
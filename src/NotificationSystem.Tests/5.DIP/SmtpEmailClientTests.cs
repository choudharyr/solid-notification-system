using NotificationSystem.Examples.DIP.Good.Services;

namespace NotificationSystem.Tests.DIP;

public class SmtpEmailClientTests
{
    private readonly SmtpEmailClient _emailClient;

    public SmtpEmailClientTests()
    {
        _emailClient = new SmtpEmailClient("smtp.test.com", 587);
    }

    [Fact]
    public void SendEmail_ExecutesWithoutException()
    {
        // Arrange
        var to = "test@example.com";
        var subject = "Test Subject";
        var body = "Test Body";

        // Act
        var exception = Record.Exception(() =>
            _emailClient.SendEmail(to, subject, body));

        // Assert
        Assert.Null(exception);
    }
}
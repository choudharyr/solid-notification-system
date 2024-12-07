using Moq;
using NotificationSystem.Final.Interfaces;
using NotificationSystem.Tests.Final.TestHelpers;
using System.Net.Mail;
using NotificationSystem.Final.Channels;

namespace NotificationSystem.Tests.Final.Channels;

public class EmailChannelTests
{
    private readonly Mock<SmtpClient> _mockSmtpClient;
    private readonly Mock<INotificationFormatter> _mockFormatter;
    private readonly EmailChannel _channel;

    public EmailChannelTests()
    {
        _mockSmtpClient = new Mock<SmtpClient>();
        _mockFormatter = new Mock<INotificationFormatter>();
        _channel = new EmailChannel(_mockSmtpClient.Object, _mockFormatter.Object);
    }

    [Fact]
    public async Task SendAsync_WithValidMessage_SendsEmail()
    {
        // Arrange
        var message = TestNotificationMessage.CreateValidEmailMessage();
        var formattedMessage = "Formatted message";
        _mockFormatter.Setup(f => f.FormatMessage(message))
            .Returns(formattedMessage);

        // Act
        var result = await _channel.SendAsync(message);

        // Assert
        Assert.True(result);
        _mockSmtpClient.Verify(c =>
            c.SendMailAsync(It.Is<MailMessage>(m =>
                m.To[0].Address == message.Recipient &&
                m.Body == formattedMessage)),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenSmtpFails_ReturnsFalse()
    {
        // Arrange
        var message = TestNotificationMessage.CreateValidEmailMessage();
        _mockSmtpClient
            .Setup(c => c.SendMailAsync(It.IsAny<MailMessage>()))
            .ThrowsAsync(new SmtpException());

        // Act
        var result = await _channel.SendAsync(message);

        // Assert
        Assert.False(result);
    }
}
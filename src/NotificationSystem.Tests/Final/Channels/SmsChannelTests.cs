using Moq;
using NotificationSystem.Final.Channels;
using NotificationSystem.Final.Interfaces;
using NotificationSystem.Tests.Final.TestHelpers;

namespace NotificationSystem.Tests.Final.Channels;

public class SmsChannelTests
{
    private readonly Mock<INotificationFormatter> _mockFormatter;
    private readonly NotificationSystem.Final.Channels.SmsChannel _channel;

    public SmsChannelTests()
    {
        _mockFormatter = new Mock<INotificationFormatter>();
        _channel = new NotificationSystem.Final.Channels.SmsChannel(_mockFormatter.Object, "test-api-key");
    }

    [Fact]
    public async Task SendAsync_WithValidMessage_SendsSms()
    {
        // Arrange
        var message = TestNotificationMessage.CreateValidSmsMessage();

        // Act
        var result = await _channel.SendAsync(message);

        // Assert
        Assert.True(result);
        _mockFormatter.Verify(f => f.FormatMessage(message), Times.Once);
    }
}
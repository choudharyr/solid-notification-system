using NotificationSystem.Final.Services;
using NotificationSystem.Tests.Final.TestHelpers;

namespace NotificationSystem.Tests.Final.Services;

public class NotificationFormatterTests
{
    private readonly NotificationFormatter _formatter;

    public NotificationFormatterTests()
    {
        _formatter = new NotificationFormatter();
    }

    [Fact]
    public void FormatMessage_IncludesAllRequiredElements()
    {
        // Arrange
        var message = TestNotificationMessage.CreateValidEmailMessage();

        // Act
        var result = _formatter.FormatMessage(message);

        // Assert
        Assert.Contains(message.Content, result);
        Assert.Contains(message.ChannelType, result);
        Assert.Contains(message.Id, result);
    }
}
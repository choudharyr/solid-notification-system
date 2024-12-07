using NotificationSystem.Final.Models;
using NotificationSystem.Final.Services;

namespace NotificationSystem.Tests.Final.Services;

public class NotificationValidatorTests
{
    private readonly NotificationValidator _validator;

    public NotificationValidatorTests()
    {
        _validator = new NotificationValidator();
    }

    [Theory]
    [InlineData("", "test@example.com", "Email")]
    [InlineData("Test", "", "Email")]
    [InlineData("Test", "invalid-email", "Email")]
    [InlineData("Test", "abc", "SMS")]
    public void Validate_WithInvalidInput_ReturnsFailure(string content, string recipient, string channelType)
    {
        // Arrange
        var message = new NotificationMessage(recipient, content, channelType);

        // Act
        var result = _validator.Validate(message);

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    [Theory]
    [InlineData("Test message", "test@example.com", "Email")]
    [InlineData("Test message", "1234567890", "SMS")]
    public void Validate_WithValidInput_ReturnsSuccess(string content, string recipient, string channelType)
    {
        // Arrange
        var message = new NotificationMessage(recipient, content, channelType);

        // Act
        var result = _validator.Validate(message);

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }
}
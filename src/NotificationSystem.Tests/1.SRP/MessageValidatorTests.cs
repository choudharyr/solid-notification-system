using NotificationSystem.Examples.SRP.Good;

namespace NotificationSystem.Tests.SRP;

public class MessageValidatorTests
{
    private readonly MessageValidator _validator;

    public MessageValidatorTests()
    {
        _validator = new MessageValidator();
    }

    [Theory]
    [InlineData(null, "test@example.com")]
    [InlineData("", "test@example.com")]
    public void ValidateMessage_WithNullOrEmptyMessage_ThrowsArgumentNullException(string message, string recipient)
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _validator.ValidateMessage(message, recipient));
    }

    [Theory]
    [InlineData("Hello", null)]
    [InlineData("Hello", "")]
    public void ValidateMessage_WithNullOrEmptyRecipient_ThrowsArgumentNullException(string message, string recipient)
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _validator.ValidateMessage(message, recipient));
    }

    [Theory]
    [InlineData("Hello", "notanemail")]
    [InlineData("Hello", "test@")]
    [InlineData("Hello", "@example.com")]
    public void ValidateMessage_WithInvalidEmail_ThrowsArgumentException(string message, string recipient)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _validator.ValidateMessage(message, recipient));
    }

    [Fact]
    public void ValidateMessage_WithValidInput_DoesNotThrowException()
    {
        // Arrange
        var message = "Hello";
        var recipient = "test@example.com";

        // Act & Assert
        var exception = Record.Exception(() => _validator.ValidateMessage(message, recipient));
        Assert.Null(exception);
    }
}
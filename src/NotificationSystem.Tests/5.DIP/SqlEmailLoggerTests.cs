using NotificationSystem.Examples.DIP.Good.Services;

namespace NotificationSystem.Tests.DIP;

public class SqlEmailLoggerTests
{
    private readonly string _testConnectionString = "Server=.;Database=TestNotifications;Trusted_Connection=True;";
    private readonly SqlEmailLogger _emailLogger;

    public SqlEmailLoggerTests()
    {
        _emailLogger = new SqlEmailLogger(_testConnectionString);
    }

    [Fact]
    public void LogEmail_ExecutesWithoutException()
    {
        // Arrange
        var message = "Test message";
        var recipient = "test@example.com";

        // Act
        var exception = Record.Exception(() =>
            _emailLogger.LogEmail(message, recipient));

        // Assert
        Assert.Null(exception);
    }
}
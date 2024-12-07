using NotificationSystem.Examples.SRP.Good;

namespace NotificationSystem.Tests.SRP;

public class NotificationLoggerTests
{
    private readonly string _testLogPath;
    private readonly NotificationLogger _logger;

    public NotificationLoggerTests()
    {
        _testLogPath = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid()}.txt");
        _logger = new NotificationLogger(_testLogPath);
    }

    [Fact]
    public void LogMessage_WritesToFile()
    {
        // Arrange
        var message = "Test log message";

        // Act
        _logger.LogMessage(message);

        // Assert
        var logContent = File.ReadAllText(_testLogPath);
        Assert.Contains(message, logContent);
        Assert.Contains(DateTime.Now.ToString("yyyy-MM-dd"), logContent);
    }

    public void Dispose()
    {
        if (File.Exists(_testLogPath)) {
            File.Delete(_testLogPath);
        }
    }
}
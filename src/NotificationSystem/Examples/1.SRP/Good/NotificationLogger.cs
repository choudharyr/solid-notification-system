namespace NotificationSystem.Examples.SRP.Good;

public class NotificationLogger
{
    private readonly string _logFilePath;

    public NotificationLogger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void LogMessage(string message)
    {
        var logMessage = $"[{DateTime.Now}] {message}{Environment.NewLine}";
        File.AppendAllText(_logFilePath, logMessage);
    }
}

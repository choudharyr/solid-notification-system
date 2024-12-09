namespace NotificationSystem.Examples.SRP.Good;

public class NotificationLogger
{
    private readonly string _logFilePath;

    public NotificationLogger(string logFilePath = "notifications.log")  // Made path optional with default
    {
        _logFilePath = logFilePath;
    }

    public void LogMessage(string recipient, string message)
    {
        File.AppendAllText(_logFilePath,
            $"Sending notification to {recipient}: {message}\n");
    }
}
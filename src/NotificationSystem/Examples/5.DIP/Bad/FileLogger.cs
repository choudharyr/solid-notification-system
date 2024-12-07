namespace NotificationSystem.Examples.DIP.Bad;

public class FileLogger
{
    private readonly string _logPath;

    public FileLogger(string logPath)
    {
        _logPath = logPath;
    }

    public void Log(string message)
    {
        File.AppendAllText(_logPath, $"[{DateTime.Now}] {message}{Environment.NewLine}");
    }
}
using NotificationSystem.Examples.DIP.Good.Interfaces;

namespace NotificationSystem.Examples.DIP.Good.Services;

public class FileEmailLogger : IEmailLogger
{
    private readonly string _logPath;

    public FileEmailLogger(string logPath)
    {
        _logPath = logPath;
    }

    public void Log(string message)
    {
        File.AppendAllText(_logPath, $"[{DateTime.Now}] {message}{Environment.NewLine}");
    }
}
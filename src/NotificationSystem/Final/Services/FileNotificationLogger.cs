using NotificationSystem.Final.Interfaces;
using NotificationSystem.Final.Models;

namespace NotificationSystem.Final.Services;

public class FileNotificationLogger : INotificationLogger
{
    private readonly string _logPath;

    public FileNotificationLogger(string logPath)
    {
        _logPath = logPath;
    }

    public async Task LogAsync(NotificationMessage message, string status, string? error = null)
    {
        var logEntry = $"""
                        [{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {message.Id}
                        Channel: {message.ChannelType}
                        Recipient: {message.Recipient}
                        Status: {status}
                        {(error != null ? $"Error: {error}" : "")}
                        """;

        await File.AppendAllTextAsync(_logPath, logEntry + Environment.NewLine);
    }
}
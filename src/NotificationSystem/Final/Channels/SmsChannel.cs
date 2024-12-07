using NotificationSystem.Final.Interfaces;
using NotificationSystem.Final.Models;

namespace NotificationSystem.Final.Channels;

public class SmsChannel : INotificationChannel
{
    private readonly INotificationFormatter _formatter;
    private readonly string _apiKey;

    public string ChannelType => "SMS";

    public SmsChannel(INotificationFormatter formatter, string apiKey)
    {
        _formatter = formatter;
        _apiKey = apiKey;
    }

    public async Task<bool> SendAsync(NotificationMessage message)
    {
        try {
            var formattedMessage = _formatter.FormatMessage(message);
            // Simulate SMS sending
            await Task.Delay(100);
            return true;
        }
        catch {
            return false;
        }
    }
}
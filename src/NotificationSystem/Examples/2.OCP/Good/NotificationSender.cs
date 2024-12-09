using NotificationSystem.Examples.OCP.Good.Interfaces;

namespace NotificationSystem.Examples.OCP.Good;

/// <summary>
/// This example demonstrates proper implementation of the Open-Closed Principle.
/// The class is:
/// - Closed for modification: Core notification logic doesn't need to change
/// - Open for extension: New channels can be added by implementing INotificationChannel
/// </summary>
public class NotificationSender
{
    private readonly IEnumerable<INotificationChannel> _channels;

    public NotificationSender(IEnumerable<INotificationChannel> channels)
    {
        _channels = channels ?? throw new ArgumentNullException(nameof(channels));
    }

    public void SendThroughAllChannels(string message, string recipient)
    {
        foreach (var channel in _channels) {
            channel.SendNotification(message, recipient);
        }
    }

    public void SendNotification(string message, string recipient, string channelName)
    {
        var channel = _channels.FirstOrDefault(c =>
            c.ChannelName.Equals(channelName, StringComparison.OrdinalIgnoreCase));

        if (channel == null)
            throw new ArgumentException($"Unsupported notification channel: {channelName}");

        channel.SendNotification(message, recipient);
    }
}
namespace NotificationSystem.Examples.LSP.Good;

public class NotificationService
{
    private readonly IList<NotificationChannel> _channels;

    public NotificationService(IList<NotificationChannel> channels)
    {
        _channels = channels ?? throw new ArgumentNullException(nameof(channels));
    }

    public bool SendMessage(string message, string recipient)
    {
        // This code works with any NotificationChannel implementation
        // because they all follow LSP
        foreach (var channel in _channels) {
            if (channel.SendMessage(message, recipient)) {
                return true;
            }
        }
        return false;
    }
}
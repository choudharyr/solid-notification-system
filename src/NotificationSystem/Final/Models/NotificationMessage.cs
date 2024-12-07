namespace NotificationSystem.Final.Models;

public class NotificationMessage
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public string Recipient { get; }
    public string Content { get; }
    public string ChannelType { get; }
    public Dictionary<string, string> Metadata { get; }
    public DateTime CreatedAt { get; }

    public NotificationMessage(
        string recipient,
        string content,
        string channelType,
        Dictionary<string, string>? metadata = null)
    {
        Recipient = recipient;
        Content = content;
        ChannelType = channelType;
        Metadata = metadata ?? new Dictionary<string, string>();
        CreatedAt = DateTime.UtcNow;
    }
}
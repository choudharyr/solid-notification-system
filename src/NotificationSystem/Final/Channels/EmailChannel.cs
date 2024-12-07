using NotificationSystem.Final.Interfaces;
using NotificationSystem.Final.Models;
using System.Net.Mail;

namespace NotificationSystem.Final.Channels;

public class EmailChannel : INotificationChannel
{
    private readonly SmtpClient _smtpClient;
    private readonly INotificationFormatter _formatter;

    public string ChannelType => "Email";

    public EmailChannel(SmtpClient smtpClient, INotificationFormatter formatter)
    {
        _smtpClient = smtpClient;
        _formatter = formatter;
    }

    public async Task<bool> SendAsync(NotificationMessage message)
    {
        try {
            var formattedMessage = _formatter.FormatMessage(message);
            var mailMessage = new MailMessage(
                "from@example.com",
                message.Recipient,
                message.Metadata.GetValueOrDefault("subject", "Notification"),
                formattedMessage);

            await _smtpClient.SendMailAsync(mailMessage);
            return true;
        }
        catch {
            return false;
        }
    }
}
using NotificationSystem.Examples.DIP.Good.Interfaces;

namespace NotificationSystem.Examples.DIP.Good;

public class EmailService
{
    private readonly IEmailClient _emailClient;
    private readonly IEmailLogger _emailLogger;

    public EmailService(
        IEmailClient emailClient,
        IEmailLogger emailLogger)
    {
        _emailClient = emailClient ?? throw new ArgumentNullException(nameof(emailClient));
        _emailLogger = emailLogger ?? throw new ArgumentNullException(nameof(emailLogger));
    }

    public void SendEmail(string to, string message)
    {
        try {
            _emailClient.SendEmail(to, "Notification", message);
            _emailLogger.LogEmail(message, to);
        }
        catch (Exception ex) {
            throw;
        }
    }
}
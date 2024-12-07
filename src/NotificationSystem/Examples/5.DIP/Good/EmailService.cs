using NotificationSystem.Examples.DIP.Good.Interfaces;

namespace NotificationSystem.Examples.DIP.Good;

public class EmailService
{
    private readonly IEmailClient _emailClient;
    private readonly IEmailRepository _emailRepository;
    private readonly IEmailLogger _logger;

    public EmailService(
        IEmailClient emailClient,
        IEmailRepository emailRepository,
        IEmailLogger logger)
    {
        _emailClient = emailClient ?? throw new ArgumentNullException(nameof(emailClient));
        _emailRepository = emailRepository ?? throw new ArgumentNullException(nameof(emailRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void SendEmail(string to, string message)
    {
        try {
            _emailClient.SendEmail(to, "Notification", message);
            _emailRepository.SaveEmailLog(to, message, DateTime.UtcNow);
            _logger.Log($"Email sent to {to}: {message}");
        }
        catch (Exception ex) {
            _logger.Log($"Error sending email: {ex.Message}");
            throw;
        }
    }
}
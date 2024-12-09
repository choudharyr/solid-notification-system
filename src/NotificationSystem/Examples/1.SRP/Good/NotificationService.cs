namespace NotificationSystem.Examples.SRP.Good;

public class NotificationService
{
    private readonly NotificationFormatter _formatter;
    private readonly NotificationLogger _logger;
    private readonly EmailSender _emailSender;
    private readonly NotificationRepository _repository;

    public NotificationService(
        NotificationFormatter formatter,
        NotificationLogger logger,
        EmailSender emailSender,
        NotificationRepository repository)
    {
        _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public void SendNotification(string message, string recipient)
    {
        try {
            var formattedMessage = _formatter.FormatMessage(message);
            _logger.LogMessage(recipient, message);
            _emailSender.SendEmail(recipient, "Notification", formattedMessage);
            _repository.Store(recipient, message);
        }
        catch (Exception ex) {
            _logger.LogMessage(recipient, $"Error: {ex.Message}");  // Basic error logging
            throw;  // Rethrow to maintain original behavior
        }
    }
}
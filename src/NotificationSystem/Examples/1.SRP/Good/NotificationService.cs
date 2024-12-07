namespace NotificationSystem.Examples.SRP.Good;

public class NotificationService
{
    private readonly MessageValidator _validator;
    private readonly MessageFormatter _formatter;
    private readonly NotificationLogger _logger;
    private readonly UserPreferenceManager _preferenceManager;
    private readonly EmailSender _emailSender;

    public NotificationService(
        MessageValidator validator,
        MessageFormatter formatter,
        NotificationLogger logger,
        UserPreferenceManager preferenceManager,
        EmailSender emailSender)
    {
        _validator = validator;
        _formatter = formatter;
        _logger = logger;
        _preferenceManager = preferenceManager;
        _emailSender = emailSender;
    }

    public void SendNotification(string message, string recipient)
    {
        try {
            // Validate
            _validator.ValidateMessage(message, recipient);

            // Check preferences
            var preferences = _preferenceManager.GetUserPreferences(recipient);
            if (!preferences.EmailNotificationsEnabled) {
                _logger.LogMessage($"Notification not sent: User {recipient} has disabled email notifications");
                return;
            }

            // Format and send
            var formattedMessage = _formatter.FormatMessage(message);
            _emailSender.SendEmail(recipient, "New Notification", formattedMessage);

            // Log success
            _logger.LogMessage($"Notification sent successfully to {recipient}");
        }
        catch (Exception ex) {
            _logger.LogMessage($"Error sending notification to {recipient}: {ex.Message}");
            throw;
        }
    }
}
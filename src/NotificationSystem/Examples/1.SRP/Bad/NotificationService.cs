using System.Net.Mail;

namespace NotificationSystem.Examples.SRP.Bad;

public class NotificationService
{
    // This class violates SRP by handling multiple responsibilities:
    // 1. Message formatting
    // 2. Message validation
    // 3. Email sending
    // 4. Logging
    // 5. User notification preferences

    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _logFilePath;

    public NotificationService(string smtpServer, int smtpPort, string logFilePath)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _logFilePath = logFilePath;
    }

    public void SendNotification(string message, string recipient)
    {
        // Validate message
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException(nameof(message));

        if (string.IsNullOrEmpty(recipient))
            throw new ArgumentNullException(nameof(recipient));

        if (!IsValidEmail(recipient))
            throw new ArgumentException("Invalid email address", nameof(recipient));

        // Format message
        var formattedMessage = $"""
            [Notification sent on {DateTime.Now}]
            
            {message}
            
            Best regards,
            Notification System
            """;

        try {
            // Check user preferences
            var userPreferences = LoadUserPreferences(recipient);
            if (!userPreferences.EmailNotificationsEnabled) {
                LogMessage($"Notification not sent: User {recipient} has disabled email notifications");
                return;
            }

            // Send email
            using (var client = new SmtpClient(_smtpServer, _smtpPort)) {
                client.Send(new MailMessage("notifications@example.com", recipient, "New Notification", formattedMessage));
            }

            // Log success
            LogMessage($"Notification sent successfully to {recipient}");
        }
        catch (Exception ex) {
            // Log error
            LogMessage($"Error sending notification to {recipient}: {ex.Message}");
            throw;
        }
    }

    private bool IsValidEmail(string email)
    {
        try {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch {
            return false;
        }
    }

    private void LogMessage(string message)
    {
        var logMessage = $"[{DateTime.Now}] {message}{Environment.NewLine}";
        File.AppendAllText(_logFilePath, logMessage);
    }

    private UserPreferences LoadUserPreferences(string userEmail)
    {
        // In a real application, this would load from a database
        // For this example, we'll just return dummy data
        return new UserPreferences { EmailNotificationsEnabled = true };
    }
}

public class UserPreferences
{
    public bool EmailNotificationsEnabled { get; set; }
}
using Microsoft.Data.SqlClient;
using System.Net.Mail;

namespace NotificationSystem.Examples.DIP.Bad;

public class EmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly SqlConnection _connection;
    private readonly FileLogger _logger;

    public EmailService()
    {
        // Direct instantiation of concrete classes
        _smtpClient = new SmtpClient("smtp.server.com", 587);
        _connection = new SqlConnection("Server=.;Database=Notifications;Trusted_Connection=True;");
        _logger = new FileLogger("email_logs.txt");
    }

    public void SendEmail(string to, string message)
    {
        try {
            // Using concrete implementations directly
            _smtpClient.Send(new MailMessage("from@example.com", to, "Subject", message));

            _connection.Open();
            using var command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO EmailLogs (To, Message, SentDate) VALUES (@to, @message, @date)";
            command.Parameters.AddWithValue("@to", to);
            command.Parameters.AddWithValue("@message", message);
            command.Parameters.AddWithValue("@date", DateTime.UtcNow);
            command.ExecuteNonQuery();

            _logger.Log($"Email sent to {to}: {message}");
        }
        catch (Exception ex) {
            _logger.Log($"Error sending email: {ex.Message}");
            throw;
        }
    }
}
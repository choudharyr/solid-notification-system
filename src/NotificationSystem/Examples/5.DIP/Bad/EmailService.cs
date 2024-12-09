using Microsoft.Data.SqlClient;
using System.Net.Mail;

namespace NotificationSystem.Examples.DIP.Bad;

public class EmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly SqlConnection _connection;

    public EmailService()
    {
        // Direct instantiation of concrete classes
        _smtpClient = new SmtpClient("smtp.server.com", 587);
        _connection = new SqlConnection("Server=.;Database=Notifications;Trusted_Connection=True;");
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
        }
        catch (Exception ex) {
            throw;
        }
    }
}
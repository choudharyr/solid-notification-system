using Microsoft.Data.SqlClient;
using System.Net.Mail;

namespace NotificationSystem.Examples.SRP.Bad;

public class NotificationService
{
    public void SendNotification(string message, string recipient)
    {
        // Format the message
        var formattedMessage = $"[{DateTime.Now}] {message}";

        // LogEmail the notification
        File.AppendAllText("notifications.log",
            $"Sending notification to {recipient}: {message}\n");

        // Send email
        using (var client = new SmtpClient()) {
            client.Send(new MailMessage("sender@example.com", recipient,
                "Notification", formattedMessage));
        }

        // Store in database
        using (var connection = new SqlConnection("connection-string")) {
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Notifications (Message, Recipient) VALUES (@message, @recipient)";

            command.Parameters.AddWithValue("@message", message);
            command.Parameters.AddWithValue("@recipient", recipient);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
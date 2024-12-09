using Microsoft.Data.SqlClient;

namespace NotificationSystem.Examples.SRP.Good;

public class NotificationRepository
{
    private readonly string _connectionString;

    public NotificationRepository(string connectionString = "Server=.;Database=Notifications;Trusted_Connection=True;")
    {
        _connectionString = connectionString;
    }

    public void Store(string recipient, string message)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = connection.CreateCommand();

        command.CommandText = "INSERT INTO Notifications (Message, Recipient) VALUES (@message, @recipient)";

        command.Parameters.AddWithValue("@message", message);
        command.Parameters.AddWithValue("@recipient", recipient);

        connection.Open();
        command.ExecuteNonQuery();
    }
}
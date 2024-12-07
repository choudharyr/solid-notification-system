using Microsoft.Data.SqlClient;
using NotificationSystem.Examples.DIP.Good.Interfaces;

namespace NotificationSystem.Examples.DIP.Good.Services;

public class SqlEmailRepository : IEmailRepository
{
    private readonly string _connectionString;

    public SqlEmailRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void SaveEmailLog(string to, string message, DateTime sentDate)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO EmailLogs (To, Message, SentDate) VALUES (@to, @message, @date)";
        command.Parameters.AddWithValue("@to", to);
        command.Parameters.AddWithValue("@message", message);
        command.Parameters.AddWithValue("@date", sentDate);
        command.ExecuteNonQuery();
    }
}
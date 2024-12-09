using Microsoft.Data.SqlClient;
using NotificationSystem.Examples.DIP.Good.Interfaces;

namespace NotificationSystem.Examples.DIP.Good.Services;

public class SqlEmailLogger : IEmailLogger
{
    private readonly string _connectionString;

    public SqlEmailLogger(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void LogEmail(string message, string recipient)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO EmailLogs (To, Message) VALUES (@to, @message, @date)";
        command.Parameters.AddWithValue("@to", recipient);
        command.Parameters.AddWithValue("@message", message);
        command.ExecuteNonQuery();
    }
}
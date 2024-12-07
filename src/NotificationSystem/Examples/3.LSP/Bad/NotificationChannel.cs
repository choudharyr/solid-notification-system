namespace NotificationSystem.Examples.LSP.Bad;

public class NotificationChannel
{
    public virtual void SendMessage(string message, string recipient)
    {
        // Base implementation for sending messages
        Console.WriteLine($"Sending message to {recipient}: {message}");
    }
}
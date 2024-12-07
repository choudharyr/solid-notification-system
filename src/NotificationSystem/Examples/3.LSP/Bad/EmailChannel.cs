namespace NotificationSystem.Examples.LSP.Bad;

public class EmailChannel : NotificationChannel
{
    public override void SendMessage(string message, string recipient)
    {
        // Violates LSP by adding stricter preconditions
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException(nameof(message));

        if (!recipient.Contains("@"))
            throw new ArgumentException("Email address must contain @", nameof(recipient));

        Console.WriteLine($"Sending email to {recipient}: {message}");
    }
}
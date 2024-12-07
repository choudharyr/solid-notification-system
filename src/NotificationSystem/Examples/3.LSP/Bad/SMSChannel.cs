namespace NotificationSystem.Examples.LSP.Bad;

public class SMSChannel : NotificationChannel
{
    public override void SendMessage(string message, string recipient)
    {
        // Violates LSP by adding different preconditions
        if (message.Length > 160)
            throw new ArgumentException("SMS messages cannot be longer than 160 characters");

        if (!recipient.All(char.IsDigit))
            throw new ArgumentException("SMS recipient must be all digits", nameof(recipient));

        Console.WriteLine($"Sending SMS to {recipient}: {message}");
    }
}
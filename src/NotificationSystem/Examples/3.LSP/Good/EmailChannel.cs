namespace NotificationSystem.Examples.LSP.Good;

public class EmailChannel : NotificationChannel
{
    protected override bool ValidateRecipient(string recipient)
    {
        return base.ValidateRecipient(recipient) && recipient.Contains("@");
    }

    protected override bool SendMessageCore(string message, string recipient)
    {
        // Email sending implementation
        Console.WriteLine($"Sending email to {recipient}: {message}");
        return true;
    }
}
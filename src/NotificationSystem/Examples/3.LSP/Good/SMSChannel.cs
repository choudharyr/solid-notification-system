namespace NotificationSystem.Examples.LSP.Good;

public class SMSChannel : NotificationChannel
{
    protected override bool ValidateMessage(string message)
    {
        return base.ValidateMessage(message) && message.Length <= 160;
    }

    protected override bool ValidateRecipient(string recipient)
    {
        return base.ValidateRecipient(recipient) && recipient.All(char.IsDigit);
    }

    protected override bool SendMessageCore(string message, string recipient)
    {
        // SMS sending implementation
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
        return true;
    }
}
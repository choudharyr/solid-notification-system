namespace NotificationSystem.Examples.LSP.Good;

public abstract class NotificationChannel
{
    protected virtual bool ValidateMessage(string message)
    {
        return !string.IsNullOrEmpty(message);
    }

    protected virtual bool ValidateRecipient(string recipient)
    {
        return !string.IsNullOrEmpty(recipient);
    }

    protected abstract bool SendMessageCore(string message, string recipient);

    public bool SendMessage(string message, string recipient)
    {
        if (!ValidateMessage(message) || !ValidateRecipient(recipient)) {
            return false;
        }

        try {
            return SendMessageCore(message, recipient);
        }
        catch {
            return false;
        }
    }
}
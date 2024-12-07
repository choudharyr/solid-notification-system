namespace NotificationSystem.Examples.SRP.Good;

public class MessageValidator
{
    public void ValidateMessage(string message, string recipient)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException(nameof(message));

        if (string.IsNullOrEmpty(recipient))
            throw new ArgumentNullException(nameof(recipient));

        if (!IsValidEmail(recipient))
            throw new ArgumentException("Invalid email address", nameof(recipient));
    }

    private bool IsValidEmail(string email)
    {
        try {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch {
            return false;
        }
    }
}
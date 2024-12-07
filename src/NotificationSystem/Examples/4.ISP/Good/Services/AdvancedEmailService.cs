using NotificationSystem.Examples.ISP.Good.Interfaces;

namespace NotificationSystem.Examples.ISP.Good.Services;

// Advanced email service implements multiple interfaces
public class AdvancedEmailService : IMessageSender, IMessageValidator, IMessageEncryption
{
    public void SendMessage(string message, string recipient)
    {
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }

    public void ValidateMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException(nameof(message));
    }

    public void ValidateRecipient(string recipient)
    {
        if (!recipient.Contains("@"))
            throw new ArgumentException("Invalid email address", nameof(recipient));
    }

    public void EncryptMessage(string message)
    {
        Console.WriteLine("Encrypting message before sending");
    }
}
namespace NotificationSystem.Examples.ISP.Bad;

public class EmailService : INotificationService
{
    public void SendMessage(string message, string recipient)
    {
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }

    // Methods that aren't relevant for simple email service
    public void ScheduleMessage(string message, string recipient, DateTime scheduleTime)
    {
        throw new NotImplementedException("Email service doesn't support scheduling");
    }

    public void CancelScheduledMessage(string messageId)
    {
        throw new NotImplementedException("Email service doesn't support scheduling");
    }

    public void GetMessageStatus(string messageId)
    {
        throw new NotImplementedException("Email service doesn't track status");
    }

    public void StoreMessageHistory(string message, string recipient)
    {
        throw new NotImplementedException("Email service doesn't store history");
    }

    public void GenerateReport(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException("Email service doesn't generate reports");
    }

    public void ValidateMessage(string message)
    {
        throw new NotImplementedException("Email service doesn't validate messages");
    }

    public void ValidateRecipient(string recipient)
    {
        throw new NotImplementedException("Email service doesn't validate recipients");
    }

    public void EncryptMessage(string message)
    {
        throw new NotImplementedException("Email service doesn't encrypt messages");
    }

    public void RetryFailedMessages()
    {
        throw new NotImplementedException("Email service doesn't retry messages");
    }
}
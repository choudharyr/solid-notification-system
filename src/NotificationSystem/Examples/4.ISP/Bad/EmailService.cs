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

    public void TrackDeliveryStatus()
    {
        throw new NotImplementedException("Email service doesn't track status");
    }

    public void StoreMessageHistory()
    {
        throw new NotImplementedException("Email service doesn't store history");
    }

    public void GenerateReport()
    {
        throw new NotImplementedException("Email service doesn't generate reports");
    }

    
}
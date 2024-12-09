using NotificationSystem.Examples.ISP.Good.Interfaces;

namespace NotificationSystem.Examples.ISP.Good.Services;

// Advanced email service implements multiple interfaces
public class AdvancedNotificationService : IMessageSender, IMessageScheduler, IMessageTracker
{
    public void SendMessage(string message, string recipient)
    {
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }

    public void ScheduleMessage(string message, string recipient, DateTime scheduleTime)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException(nameof(message));
    }

    public void CancelScheduledMessage(string messageId)
    {
        throw new NotImplementedException();
    }

    public void TrackDeliveryStatus()
    {
        throw new NotImplementedException();
    }
}
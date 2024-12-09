using NotificationSystem.Examples.ISP.Good.Interfaces;

namespace NotificationSystem.Examples.ISP.Good.Services;

// Enterprise email service implements even more interfaces
public class EnterpriseNotificationService :
    IMessageSender,
    IMessageScheduler,
    IMessageTracker,
    IMessageStorage,
    IReportGenerator
{
    public void SendMessage(string message, string recipient)
    {
        Console.WriteLine($"Sending enterprise email to {recipient}: {message}");
    }

    public void ScheduleMessage(string message, string recipient, DateTime scheduleTime)
    {
        Console.WriteLine($"Scheduling email for {scheduleTime}");
    }

    public void CancelScheduledMessage(string messageId)
    {
        Console.WriteLine($"Cancelling scheduled email {messageId}");
    }

    public void TrackDeliveryStatus()
    {
        throw new NotImplementedException();
    }

    public void StoreMessageHistory()
    {
        throw new NotImplementedException();
    }

    public void GenerateReport()
    {
        throw new NotImplementedException();
    }
}
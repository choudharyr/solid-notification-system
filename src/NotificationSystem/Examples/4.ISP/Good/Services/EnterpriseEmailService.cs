using NotificationSystem.Examples.ISP.Good.Interfaces;

namespace NotificationSystem.Examples.ISP.Good.Services;

// Enterprise email service implements even more interfaces
public class EnterpriseEmailService :
    IMessageSender,
    IMessageScheduler,
    IMessageTracker,
    IMessageStore,
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

    public void GetMessageStatus(string messageId)
    {
        Console.WriteLine($"Getting status for message {messageId}");
    }

    public void StoreMessageHistory(string message, string recipient)
    {
        Console.WriteLine("Storing message in history");
    }

    public void GenerateReport(DateTime startDate, DateTime endDate)
    {
        Console.WriteLine($"Generating report from {startDate} to {endDate}");
    }
}
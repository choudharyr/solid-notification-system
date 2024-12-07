namespace NotificationSystem.Examples.ISP.Good.Interfaces;

public interface IMessageScheduler
{
    void ScheduleMessage(string message, string recipient, DateTime scheduleTime);
    void CancelScheduledMessage(string messageId);
}
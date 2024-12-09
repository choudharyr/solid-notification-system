namespace NotificationSystem.Examples.ISP.Bad;

public interface INotificationService
{
    void SendMessage(string message, string recipient);
    void ScheduleMessage(string message, string recipient, DateTime scheduleTime);
    void CancelScheduledMessage(string messageId);
    void TrackDeliveryStatus();
    void StoreMessageHistory();
    void GenerateReport();
}
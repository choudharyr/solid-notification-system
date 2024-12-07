namespace NotificationSystem.Examples.ISP.Bad;

public interface INotificationService
{
    void SendMessage(string message, string recipient);
    void ScheduleMessage(string message, string recipient, DateTime scheduleTime);
    void CancelScheduledMessage(string messageId);
    void GetMessageStatus(string messageId);
    void StoreMessageHistory(string message, string recipient);
    void GenerateReport(DateTime startDate, DateTime endDate);
    void ValidateMessage(string message);
    void ValidateRecipient(string recipient);
    void EncryptMessage(string message);
    void RetryFailedMessages();
}
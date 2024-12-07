namespace NotificationSystem.Examples.ISP.Good.Interfaces;

public interface IRetryPolicy
{
    void RetryFailedMessages();
}
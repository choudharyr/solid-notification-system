namespace NotificationSystem.Examples.ISP.Good.Interfaces;

public interface IMessageStore
{
    void StoreMessageHistory(string message, string recipient);
}
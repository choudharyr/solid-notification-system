namespace NotificationSystem.Examples.ISP.Good.Interfaces;

public interface IMessageSender
{
    void SendMessage(string message, string recipient);
}
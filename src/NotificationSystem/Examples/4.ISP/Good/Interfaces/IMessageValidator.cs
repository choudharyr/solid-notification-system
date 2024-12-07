namespace NotificationSystem.Examples.ISP.Good.Interfaces;

public interface IMessageValidator
{
    void ValidateMessage(string message);
    void ValidateRecipient(string recipient);
}
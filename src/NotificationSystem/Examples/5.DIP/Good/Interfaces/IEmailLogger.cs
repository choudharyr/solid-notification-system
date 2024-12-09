namespace NotificationSystem.Examples.DIP.Good.Interfaces;

public interface IEmailLogger
{
    void LogEmail(string message, string recipient);
}
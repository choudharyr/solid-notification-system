namespace NotificationSystem.Examples.DIP.Good.Interfaces;

public interface IEmailRepository
{
    void SaveEmailLog(string to, string message, DateTime sentDate);
}
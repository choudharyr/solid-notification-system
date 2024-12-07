namespace NotificationSystem.Examples.DIP.Good.Interfaces;

public interface IEmailClient
{
    void SendEmail(string to, string subject, string message);
}
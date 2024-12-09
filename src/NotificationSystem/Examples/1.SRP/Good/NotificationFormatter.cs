namespace NotificationSystem.Examples.SRP.Good;

public class NotificationFormatter
{
    public string FormatMessage(string message)
    {
        return $"[{DateTime.Now}] {message}";
    }
}
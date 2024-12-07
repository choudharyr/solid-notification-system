using NotificationSystem.Examples.SRP.Good.Models;

namespace NotificationSystem.Examples.SRP.Good;

public class UserPreferenceManager
{
    public UserPreferences GetUserPreferences(string userEmail)
    {
        // In a real application, this would load from a database
        return new UserPreferences { EmailNotificationsEnabled = true };
    }
}

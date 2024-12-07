using NotificationSystem.Final.Interfaces;
using NotificationSystem.Final.Models;

namespace NotificationSystem.Final;

public class NotificationService
{
    private readonly IEnumerable<INotificationChannel> _channels;
    private readonly INotificationValidator _validator;
    private readonly INotificationLogger _logger;

    public NotificationService(
        IEnumerable<INotificationChannel> channels,
        INotificationValidator validator,
        INotificationLogger logger)
    {
        _channels = channels;
        _validator = validator;
        _logger = logger;
    }

    public async Task<bool> SendNotificationAsync(NotificationMessage message)
    {
        try {
            // Validate the message
            var validationResult = _validator.Validate(message);
            if (!validationResult.IsValid) {
                await _logger.LogAsync(message, "Validation Failed",
                    string.Join(", ", validationResult.Errors));
                return false;
            }

            // Find the appropriate channel
            var channel = _channels.FirstOrDefault(c =>
                c.ChannelType.Equals(message.ChannelType, StringComparison.OrdinalIgnoreCase));

            if (channel == null) {
                await _logger.LogAsync(message, "Failed", "Unsupported channel type");
                return false;
            }

            // Send the notification
            var result = await channel.SendAsync(message);
            await _logger.LogAsync(message, result ? "Sent" : "Failed");
            return result;
        }
        catch (Exception ex) {
            await _logger.LogAsync(message, "Error", ex.Message);
            return false;
        }
    }
}
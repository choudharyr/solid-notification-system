using NotificationSystem.Examples.ISP.Good.Interfaces;
using NotificationSystem.Examples.ISP.Good.Services;

namespace NotificationSystem.Tests.ISP;

public class InterfaceSegregationTests
{
    [Fact]
    public void CanUseServicesThroughSpecificInterfaces()
    {
        // Arrange
        var simpleService = new SimpleNotificationService();
        var advancedService = new AdvancedNotificationService();

        // Act & Assert
        UseMessageSender(simpleService);
        UseMessageSender(advancedService);
        UseMessageScheduler(advancedService);
        UseMessageTracker(advancedService);
    }

    private void UseMessageSender(IMessageSender sender)
    {
        sender.SendMessage("Test", "recipient");
    }

    private void UseMessageScheduler(IMessageScheduler scheduler)
    {
        scheduler.ScheduleMessage("Test", "recipient", DateTime.Now.AddHours(1));
    }

    private void UseMessageTracker(IMessageTracker tracker)
    {
        tracker.TrackDeliveryStatus();
    }

    [Fact]
    public void ServicesImplementOnlyRequiredInterfaces()
    {
        // Arrange
        var simpleService = new SimpleNotificationService();
        var advancedService = new AdvancedNotificationService();

        // Assert - Simple Service
        Assert.True(simpleService is IMessageSender);
        Assert.False(simpleService is IMessageScheduler);
        Assert.False(simpleService is IMessageTracker);
        Assert.False(simpleService is IMessageStorage);
        Assert.False(simpleService is IReportGenerator);

        // Assert - Advanced Service
        Assert.True(advancedService is IMessageSender);
        Assert.True(advancedService is IMessageScheduler);
        Assert.True(advancedService is IMessageTracker);
        Assert.False(advancedService is IMessageStorage);
        Assert.False(advancedService is IReportGenerator);
    }
}
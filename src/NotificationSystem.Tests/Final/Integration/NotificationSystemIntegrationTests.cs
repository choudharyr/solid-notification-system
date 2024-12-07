using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationSystem.Final;
using NotificationSystem.Tests.Final.TestHelpers;
using NotificationSystem.Final.Configuration;

namespace NotificationSystem.Tests.Final.Integration;

public class NotificationSystemIntegrationTests
{
    private readonly IServiceProvider _serviceProvider;

    public NotificationSystemIntegrationTests()
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string> {
                ["Email:SmtpServer"] = "localhost",
                ["Email:Port"] = "25",
                ["Sms:ApiKey"] = "test-key",
                ["Logging:FilePath"] = Path.GetTempFileName()
            })
            .Build();

        services.AddNotificationSystem(configuration);
        _serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public async Task CompleteNotificationFlow_WithValidEmail_Succeeds()
    {
        // Arrange
        var service = _serviceProvider.GetRequiredService<NotificationService>();
        var message = TestNotificationMessage.CreateValidEmailMessage();

        // Act
        var result = await service.SendNotificationAsync(message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CompleteNotificationFlow_WithValidSms_Succeeds()
    {
        // Arrange
        var service = _serviceProvider.GetRequiredService<NotificationService>();
        var message = TestNotificationMessage.CreateValidSmsMessage();

        // Act
        var result = await service.SendNotificationAsync(message);

        // Assert
        Assert.True(result);
    }
}
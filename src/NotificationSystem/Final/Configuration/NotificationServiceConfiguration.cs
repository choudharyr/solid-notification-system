using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationSystem.Final.Channels;
using NotificationSystem.Final.Interfaces;
using NotificationSystem.Final.Services;

namespace NotificationSystem.Final.Configuration;

public static class NotificationServiceConfiguration
{
    public static IServiceCollection AddNotificationSystem(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register channels
        services.AddScoped<INotificationChannel, EmailChannel>(sp =>
            new EmailChannel(
                new SmtpClient(
                    configuration["Email:SmtpServer"],
                    int.Parse(configuration["Email:Port"])),
                sp.GetRequiredService<INotificationFormatter>()
            ));

        services.AddScoped<INotificationChannel, Channels.SmsChannel>(sp =>
            new Channels.SmsChannel(
                sp.GetRequiredService<INotificationFormatter>(),
                configuration["Sms:ApiKey"]
            ));

        // Register supporting services
        services.AddScoped<INotificationFormatter, NotificationFormatter>();
        services.AddScoped<INotificationValidator, NotificationValidator>();
        services.AddScoped<INotificationLogger>(sp =>
            new FileNotificationLogger(configuration["Logging:FilePath"]));

        // Register main service
        services.AddScoped<NotificationService>();

        return services;
    }
}
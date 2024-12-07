using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationSystem.Examples.DIP.Good.Interfaces;
using NotificationSystem.Examples.DIP.Good.Services;

namespace NotificationSystem.Examples.DIP.Good.Configuration;

public static class EmailServiceConfiguration
{
    public static IServiceCollection AddEmailService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IEmailClient>(sp =>
            new SmtpEmailClient(
                configuration["Email:SmtpServer"],
                int.Parse(configuration["Email:Port"])
            ));

        services.AddScoped<IEmailRepository>(sp =>
            new SqlEmailRepository(
                configuration.GetConnectionString("DefaultConnection")
            ));

        services.AddScoped<IEmailLogger>(sp =>
            new FileEmailLogger(
                configuration["Logging:FilePath"]
            ));

        services.AddScoped<EmailService>();

        return services;
    }
}
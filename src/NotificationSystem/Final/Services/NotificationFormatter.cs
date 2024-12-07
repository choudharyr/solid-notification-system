using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Final.Interfaces;
using NotificationSystem.Final.Models;

namespace NotificationSystem.Final.Services;

public class NotificationFormatter : INotificationFormatter
{
    public string FormatMessage(NotificationMessage message)
    {
        return $"""
                {message.Content}

                Sent via {message.ChannelType}
                Message ID: {message.Id}
                """;
    }
}
using SmartHub_NotificatioSystem.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Extensions
{
    public static class MessageFormatter
    {
        public static string FormatMessage(this NotificationEventArgs notification)
        {
            return $"[Notification] Type: {notification.NotificationType}, Message: {notification.NotificationMessage}";
        }
    }
}

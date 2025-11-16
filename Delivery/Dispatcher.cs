using SmartHub_NotificatioSystem.Events;
using SmartHub_NotificatioSystem.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Delivery
{
    public static class Dispatcher
    {
        public static async Task SendNotificationAsync(Subscriber subscriber, NotificationEventArgs notification)
        {
            Console.WriteLine($"Dispatching to {subscriber.Name}...");
            await Task.Delay(500); // simulate network delay
            Console.WriteLine($"Notification delivered to {subscriber.Name}: {notification.NotificationMessage}");
        }
    }
}

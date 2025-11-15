using SmartHub_NotificatioSystem.Events;
using System;

namespace SmartHub_NotificatioSystem.Publishers
{
    public class Publisher
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Publisher(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }

    public class EventPublisher
    {
        // Declare the event using EventHandler<T>
        public event EventHandler<NotificationEventArgs> NotificationPublished;

        // Publishes a basic notification
        public void UpdateNotificationStatus(string notification)
        {
            Console.WriteLine($"[Publisher]: Notification has been published with {notification}");

            // Safe event invocation
            NotificationPublished?.Invoke(
                this,
                new NotificationEventArgs(notification)
            );
        }

        // Optional override-friendly method
        protected virtual void OnNotificationPublished(NotificationEventArgs e)
        {
            NotificationPublished?.Invoke(this, e);
        }
    }
}

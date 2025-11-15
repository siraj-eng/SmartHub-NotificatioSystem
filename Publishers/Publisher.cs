using SmartHub_NotificatioSystem.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //The main publisher class
        public class EventPublisher
        {
            //Declare the event using EventHandler<T> delegate type
            public event EventHandler<NotificationEventArgs> NotificationPublished;

            //A method in the publisher that triggers the event
            public void UpdateNotificationStatus(string notification)
            {
                Console.WriteLine($"[Publisher]: Notification has been published with {notification}");

                //Call the safe invocation method
                NotificationPublished(new  NotificationEventArgs(notification));
            }

            //Protected virtual method for thread-safe invocation
            protected virtual void OnPublisherChanged(EventArgs e) 
            {
                //using the null conditional operator to invoke only if the subscribers exist
                NotificationPublished?.Invoke(this, e);
            }
        }
    }

}

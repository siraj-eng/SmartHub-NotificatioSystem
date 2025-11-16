using SmartHub_NotificatioSystem.Events;
using SmartHub_NotificatioSystem.Publishers;
using SmartHub_NotificatioSystem.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Hub
{
    public class NotificationHub
    {

        // Tracks all registered subscribers
        public List<Subscriber> subscribers;

        public event EventHandler<SubscriberEventsArgs> SubscriberAdded;
        public event EventHandler<SubscriberEventsArgs> SubscriberRemoved;
        public event EventHandler<NotificationEventArgs> NotificationPublished;

        // Constructor
        public NotificationHub()
        {
            subscribers = new List<Subscriber>();
        }

        /*
         * Methods - Subscriber - Adds subscriber to the list
         */

        //Subscribe method - with a trigger event
        public void Subscribe(Subscriber subscriber)
        {
            if (!subscribers.Contains(subscriber))
            {
                subscribers.Add(subscriber);
                Console.WriteLine($"Subscriber {subscriber.Name} registered successfully.");

                SubscriberAdded?.Invoke(this, new SubscriberEventsArgs(subscriber));

            }
        }
        
        //Unscribe method subscriber - With a trigger an event
        public void Unscribe(Subscriber subscriber)
        {
            if (subscribers.Contains(subscriber))
            {
                subscribers.Remove(subscriber);
                Console.WriteLine($"Subscriber {subscriber.Name} unregistered successfully.");

                SubscriberRemoved?.Invoke(this, new SubscriberEventsArgs(subscriber));  

            }
        }

        //Placeholder for PublishNotification method - will filter subscribers and send notification
        public async Task PublishNotification(NotificationEventArgs e)
        {
            var relevantSubscribers = subscribers
                                     .Where(s => s.SubscriptionPreference.Contains(e.NotificationType))
                                     .ToList();

            foreach (var subscriber in relevantSubscribers) 
            {
                await subscriber.RecieveNotifications(e);
            }
        }

        // Wire a publisher into the hub
        public void AttachPublisher(MarketingPublisher publisher)
        {
            //Link publisher event -> hub event handler
            publisher.MarketingCampaignLaunched += OnMarketingCampaignLaunched;

            Console.WriteLine("MarketingPublisher successfully attached to NotificationHub.");
        }

        //This fires when the publisher launches a campaign
        private async void OnMarketingCampaignLaunched(object sender, NotificationEventArgs e)
        {
            Console.WriteLine($"Hub recieved Marketing event: {e.NotificationMessage}");

            await PublishNotification(e);
        }

    }
} 
   


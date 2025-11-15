using SmartHub_NotificatioSystem.Events;
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
        private List<Subscriber> subscribers;

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
            } 
        }
        
        //Unscribe method subscriber - With a trigger an event
        public void Unscribe(Subscriber subscriber)
        {
            if (subscribers.Contains(subscriber))
            {
                subscribers.Remove(subscriber);
                Console.WriteLine($"Subscriber {subscriber.Name} unregistered successfully.");
            }
        }

    }
} 
   


using SmartHub_NotificatioSystem.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Subscribers
{
    public class Subscribers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details {  get; set; }
        public List<string> SubscriptionPreference { get; private set; } = new List<string>();


        public Subscribers(int id, string name, string description, string details)
        {
            Id = id;
            Name = name;
            Description = description;
            Details = details;
            
        }

        //Declare the list independently
        public Subscribers()
        {
            SubscriptionPreference = new List<string>();
        }

        //Method - RecieveNotifiactions
        public async Task RecieveNotifications(NotificationEventArgs e)
        {
            Console.WriteLine($"Subscriber{Name} recieved Notification....");

            await Task.Delay(1000);

            Console.WriteLine($"Notification recieved successfully : {e.NotificationMessage}");

        }

    }
}

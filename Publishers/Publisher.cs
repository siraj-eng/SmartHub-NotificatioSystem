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
            public event EventHandler<EventArgs> PublisherChanged;

            //A method in the publisher that triggers the event
            public void UpdateStatus(string message)
            {
                Console.WriteLine($"[Publisher]: Status of Publisher has changed to...");

                //Call the safe invocation method
                OnPublisherChanged(new EventArgs(message));
            }

            //Protected virtual method for thread-safe invocation
            protected virtual void OnPublisherChanged(EventArgs e) 
            {
                //using the null conditional operator to invoke only if the subscribers exist
                PublisherChanged?.Invoke(this, e);
            }
        }
    }

}

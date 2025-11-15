using SmartHub_NotificatioSystem.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Events
{
    public class SubscriberEventsArgs : EventArgs
    {
        public Subscriber Subscriber { get; }

        public SubscriberEventsArgs(Subscriber subscriber)
        {
            Subscriber = subscriber;
        }
    }
}

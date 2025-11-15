using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Subscribers
{
    public class SubscriberPreference
    {

        public int SubcsriberId {  get; set; }
        public int SubscriptionId { get; set; } = 0;
        public string SubsriptionPreference { get; set; } 

        //constructor
        public SubscriberPreference(int subscriberid, int subsriptionid, string subsciptionpreference) 
        { 
            SubcsriberId = subscriberid;
            SubscriptionId = subsriptionid;
            SubsriptionPreference = subsciptionpreference;

        }
    }
}

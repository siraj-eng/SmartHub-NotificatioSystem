using SmartHub_NotificatioSystem.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Publishers
{
    public class MarketingPublisher : Publisher
    {
        public MarketingPublisher(string id, string name, string description) : base(id, name, description)
        {

        }

        //Needs one event - Marketing Campaign Launched
        public event EventHandler<NotificationEventArgs> MarketingCampaignLaunched;

        //Launch Campaign Required
        public void LaunchCampaign(int notificationId, string notificationType, string notificationDescription, string notificatinoMessage)
        {
            if (notificationId == 0)
            {
                Console.WriteLine("Invalid Notificatin id.Try again!");
                return;
            }

            Console.WriteLine($"Launching market campaign: {notificatinoMessage} with Descrption as follows {notificationDescription}");

            //to bundle all the notification details in one package
            var args = new NotificationEventArgs(
                       notificationId,
                       notificationType,
                       notificationDescription,
                       notificatinoMessage);

            onMarketingCampaignLaunched(args);

        }

        //Protected method
        protected virtual void onMarketingCampaignLaunched(NotificationEventArgs e) 
        {
            //Trigger the MarketingCampaignLaunch
            MarketingCampaignLaunched?.Invoke(this, e);
        }

    }
}

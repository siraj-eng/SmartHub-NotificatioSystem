using SmartHub_NotificatioSystem.Events;
using System;

namespace SmartHub_NotificatioSystem.Publishers
{
    public class MarketingPublisher : Publisher
    {
        // Event fired when a marketing campaign is launched
        public event EventHandler<NotificationEventArgs> MarketingCampaignLaunched;

        public MarketingPublisher(string id, string name, string description)
            : base(id, name, description)
        {
        }

        // Launch a marketing campaign + trigger event
        public void LaunchCampaign(
            int notificationId,
            string notificationType,
            string notificationDescription,
            string notificationMessage)
        {
            if (notificationId <= 0)
            {
                Console.WriteLine("[Publisher] Invalid notification ID. Campaign aborted.");
                return;
            }

            Console.WriteLine(
                $"[Publisher] Launching Campaign: '{notificationMessage}' | Description: {notificationDescription}");

            // Create notification args
            var notificationEvent = new NotificationEventArgs(
                notificationId,
                notificationMessage,
                notificationType,
                notificationDescription
            );

            // Trigger event safely
            OnMarketingCampaignLaunched(notificationEvent);
        }

        // Protected virtual event trigger (allows override)
        protected virtual void OnMarketingCampaignLaunched(NotificationEventArgs e)
        {
            MarketingCampaignLaunched?.Invoke(this, e);
        }
    }
}

using SmartHub_NotificatioSystem.Hub;
using SmartHub_NotificatioSystem.Publishers;
using SmartHub_NotificatioSystem.Subscribers;
using SmartHub_NotificatioSystem.Events;
using SmartHub_NotificatioSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hub = new NotificationHub();
            var marketingPublisher = new MarketingPublisher("M001", "MarketingPublisher", "Publishes marketing campaigns");

            // Subscribe hub to marketing events
            marketingPublisher.MarketingCampaignLaunched += async (sender, e) => await hub.PublishNotification(e);

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Smart Notifications Hub ===");
                Console.WriteLine("1. Add Subscriber");
                Console.WriteLine("2. Remove Subscriber");
                Console.WriteLine("3. List Subscribers");
                Console.WriteLine("4. Publish System Notification");
                Console.WriteLine("5. Launch Marketing Campaign");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddSubscriberMenu(hub);
                        break;

                    case "2":
                        RemoveSubscriberMenu(hub);
                        break;

                    case "3":
                        ListSubscribersMenu(hub);
                        break;

                    case "4":
                        await PublishSystemNotificationMenu(hub);
                        break;

                    case "5":
                        LaunchMarketingCampaignMenu(marketingPublisher);
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }

            Console.WriteLine("Exiting Smart Notifications Hub. Goodbye!");
        }

        // ID generator
        static int currentId = 1;
        static int GenerateId() => currentId++;

        // Menu Methods
        static void AddSubscriberMenu(NotificationHub hub)
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();

            Console.Write("Enter Description: ");
            var desc = Console.ReadLine();

            Console.Write("Enter Details: ");
            var details = Console.ReadLine();

            Console.Write("Enter Subscription Types (comma separated, e.g., System,Marketing): ");
            var types = Console.ReadLine()?.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var subscriber = new Subscriber(GenerateId(), name, desc, details, new List<string>(types ?? Array.Empty<string>()));

            hub.Subscribe(subscriber);
        }

        static void RemoveSubscriberMenu(NotificationHub hub)
        {
            Console.Write("Enter Subscriber ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int removeId))
            {
                var toRemove = hub.subscribers.FirstOrDefault(s => s.Id == removeId);
                if (toRemove != null)
                {
                    hub.Unscribe(toRemove);
                }
                else
                {
                    Console.WriteLine("Subscriber not found!");
                }
            }
        }

        static void ListSubscribersMenu(NotificationHub hub)
        {
            Console.WriteLine("=== Subscribers ===");
            foreach (var sub in hub.subscribers)
            {
                Console.WriteLine($"{sub.Id}: {sub.Name} - {string.Join(",", sub.SubscriptionPreferences)}");
            }
        }

        static async Task PublishSystemNotificationMenu(NotificationHub hub)
        {
            Console.Write("Enter Notification Message: ");
            var msg = Console.ReadLine();

            var systemNotification = new NotificationEventArgs(
                GenerateId(),
                Constants.SystemType,
                "System Update",
                msg
            );

            await hub.PublishNotification(systemNotification);
        }

        static void LaunchMarketingCampaignMenu(MarketingPublisher marketingPublisher)
        {
            Console.Write("Enter Marketing Campaign Message: ");
            var msg = Console.ReadLine();

            marketingPublisher.LaunchCampaign(
                GenerateId(),
                Constants.MarketingType,
                "Campaign",
                msg
            );
        }
    }
}

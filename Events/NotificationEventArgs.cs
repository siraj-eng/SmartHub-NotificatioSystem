using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Events
{
    public class NotificationEventArgs : EventArgs
    {
        public int NotificationId { get; set; }
        public string NotificationMessage { get; set; }
        public string NotificationType { get; set; }
        public string NotificationDescription { get; set; }
        public NotificationEventArgs (string notification) => NotificationMessage = notification;

        //Constructor Overloading
        public NotificationEventArgs(int notificationId, string notificationType, string notificationDescription, string notificationMessage)
        {
            NotificationId = notificationId;
            NotificationType = notificationType;
            NotificationDescription = notificationDescription;
            NotificationMessage = notificationMessage;
        }
    }
}

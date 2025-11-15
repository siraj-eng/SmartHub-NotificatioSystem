using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationTitle { get; set; }
        public string NotitficationMessage { get; set; }
        public string senderName {  get; set; }
        
        //Constructor
        public Notification(int id, string notificationtitle, string notificationmessage, string sendername)
        {
            Id = id;
            NotificationTitle = notificationtitle;
            NotitficationMessage = notificationmessage;
            senderName = sendername;
            
        }

    }
}

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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        //Constructor
        public Notification(int id, string name, string description)
        {
            Id = id;    
            Name = name;
            Description = description;

        }

    }
}

using System;
using System.Collections.Generic;

namespace MigrationApp_s20540_Kolokwium.Models
{
    public class Event
    {
        public int IdEvent { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<Artist_Event> Artist_Events { get; set; }

        public virtual ICollection<Event_Organiser> Event_Organisers { get; set; }
    }
}

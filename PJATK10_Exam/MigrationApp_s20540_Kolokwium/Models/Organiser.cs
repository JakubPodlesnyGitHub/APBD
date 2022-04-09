using System.Collections.Generic;

namespace MigrationApp_s20540_Kolokwium.Models
{
    public class Organiser
    {
        public int IdOrganiser { get; set; }

        public string OrganiserName { get; set; }
        
        public virtual ICollection<Event_Organiser> Event_Organisers { get; set; }
    }
}

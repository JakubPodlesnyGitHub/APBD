using System;

namespace MigrationApp_s20540_Kolokwium.Models
{
    public class Artist_Event
    {
        public int IdArtist { get; set; }
        
        public int IdEvent { get; set; }

        public DateTime PerformanceDate { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual Event Event { get; set; }
    }
}

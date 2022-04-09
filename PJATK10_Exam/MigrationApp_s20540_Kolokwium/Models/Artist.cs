using System.Collections.Generic;

namespace MigrationApp_s20540_Kolokwium.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }

        public string NickName { get; set; }

        public virtual ICollection<Artist_Event> Artist_Events { get; set; }
    }
}

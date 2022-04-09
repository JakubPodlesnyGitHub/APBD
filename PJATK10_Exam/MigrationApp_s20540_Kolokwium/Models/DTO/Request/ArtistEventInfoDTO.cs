using Microsoft.AspNetCore.Mvc;
using System;

namespace MigrationApp_s20540_Kolokwium.Models.DTO.Request
{
    public class ArtistEventInfoDTO
    {
        public int IdArtist { get; set; }

        public int IdEvent { get; set; }

        public DateTime NewDateTimePerformance { get; set; }
    }
}

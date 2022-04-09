using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.Models.DTO.Responses
{
    public class GetArtistInfoDTO
    {
        public int IdArtist { get; set; }

        public string NickName { get; set; }

        public IEnumerable<GetEventInfoDTO> EventsList { get; set; }
    }
}

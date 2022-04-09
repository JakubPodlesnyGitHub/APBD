using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.Models.DTO.Responses
{
    public class GetEventInfoDTO
    {
        public int IdEvent { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

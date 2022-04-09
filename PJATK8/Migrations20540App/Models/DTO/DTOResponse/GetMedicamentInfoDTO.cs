using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations20540App.Models.DTO.DTOResponse
{
    public class GetMedicamentInfoDTO
    {

        public string Name { get; set; }

        public string Descritpion { get; set; }

        public string Type { get; set; }

        public int? Dose { get; set; }

        public string Details { get; set; }
    }
}

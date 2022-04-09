using System;
using System.Collections.Generic;

namespace Migrations20540App.Models.DTO.DTOResponse
{
    public class GetPrescriptionInfoDTO
    {
        public int IdPrescription { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        public GetDoctorInfoDTO Doctor { get; set; }

        public GetPatientInfoDTO Patient { get; set; }

        public IEnumerable<GetMedicamentInfoDTO> Medicaments { get; set; }
    }
}

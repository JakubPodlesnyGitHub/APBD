using System;

namespace Migrations20540App.Models.DTO.DTOResponse
{
    public class GetPatientInfoDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}

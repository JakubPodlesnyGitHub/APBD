using Migrations20540App.Models.DTO.DTOResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations20540App.InterFaces
{
    public interface IPrescriptionDataBase
    {
        public Task<GetPrescriptionInfoDTO> GetPrescription(int idPrescription);
    }
}

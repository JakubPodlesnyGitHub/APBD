using Migrations20540App.Models.DTO.DTORequest;
using Migrations20540App.Models.DTO.DTOResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Migrations20540App.InterFaces
{
    public interface IDoctorDataBase
    {
        public Task<IEnumerable<GetDoctorInfoDTO>> GetDoctors();
        public Task<string> DeleteDoctor(int idDoctor);
        public Task<bool> AddNewDoctor(DoctorInfoDTO doctorDTOInfo);
        public Task<bool> UpdateDoctor(DoctorInfoDTO doctorInfoDTO, int idDoctor);
    }
}

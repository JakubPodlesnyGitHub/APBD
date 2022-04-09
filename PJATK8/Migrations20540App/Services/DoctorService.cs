using Microsoft.EntityFrameworkCore;
using Migrations20540App.InterFaces;
using Migrations20540App.Models;
using Migrations20540App.Models.DTO.DTORequest;
using Migrations20540App.Models.DTO.DTOResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations20540App.Services
{

    public class DoctorService : IDoctorDataBase
    {
        private s20540DbContext _s20540DbContext;

        public DoctorService(s20540DbContext s20540DbContext)
        {
            this._s20540DbContext = s20540DbContext;
        }

        public async Task<IEnumerable<GetDoctorInfoDTO>> GetDoctors()
        {
            return await _s20540DbContext.Doctors.Select(d => new GetDoctorInfoDTO { FirstName = d.FirstName, LastName = d.LastName, Email = d.Email }).ToListAsync();
        }

        public async Task<string> DeleteDoctor(int idDoctor)
        {
            if (!await _s20540DbContext.Doctors.AnyAsync(d => d.IdDoctor == idDoctor))
                throw new Exception("There is no such doctor");

            if (await _s20540DbContext.Doctors.Include(d => d.DoctorPrescriptions).AnyAsync(d => d.DoctorPrescriptions.Any(dp => dp.IdDoctor == idDoctor)))
                throw new Exception("The doctor was not deleted because it was bound to another table");

            var doctorToRemoved = await _s20540DbContext.Doctors.FirstAsync(d => d.IdDoctor == idDoctor);
            _s20540DbContext.Doctors.Attach(doctorToRemoved);
            _s20540DbContext.Entry(doctorToRemoved).State = EntityState.Deleted;
            await _s20540DbContext.SaveChangesAsync();
            return "The doctor has been deleted: " + doctorToRemoved.FirstName + " " + doctorToRemoved.LastName;
        }

        public async Task<bool> AddNewDoctor(DoctorInfoDTO doctorDTOInfo)
        {
            if (await _s20540DbContext.Doctors.AnyAsync(d => d.FirstName == doctorDTOInfo.FirstName && d.LastName == doctorDTOInfo.LastName && d.Email == doctorDTOInfo.Email))
                return false;

            var addedDoctor = new Doctor
            {
                FirstName = doctorDTOInfo.FirstName,
                LastName = doctorDTOInfo.LastName,
                Email = doctorDTOInfo.Email
            };

            _s20540DbContext.Doctors.Attach(addedDoctor);
            _s20540DbContext.Entry(addedDoctor).State = EntityState.Added;
            await _s20540DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateDoctor(DoctorInfoDTO doctorInfoDTO, int idDoctor)
        {
            if (!await _s20540DbContext.Doctors.AnyAsync(d => d.IdDoctor == idDoctor))
                return false;

            var doctor = await _s20540DbContext.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == idDoctor);

            doctor.FirstName = doctorInfoDTO.FirstName;
            doctor.LastName = doctorInfoDTO.LastName;
            doctor.Email = doctorInfoDTO.Email;

            await _s20540DbContext.SaveChangesAsync();
            return true;
        }

    }
}

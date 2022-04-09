using Microsoft.EntityFrameworkCore;
using Migrations20540App.InterFaces;
using Migrations20540App.Models;
using Migrations20540App.Models.DTO.DTOResponse;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations20540App.Services
{
    public class PrescriptionService : IPrescriptionDataBase
    {

        private s20540DbContext _s20540DbContext;

        public PrescriptionService(s20540DbContext s20540DbContext)
        {
            this._s20540DbContext = s20540DbContext;
        }


        public async Task<GetPrescriptionInfoDTO> GetPrescription(int idPrescription)
        {
            if (!await _s20540DbContext.Prescriptions.AnyAsync(p => p.IdPrescription == idPrescription))
                return null;
            return await _s20540DbContext.Prescriptions.Include(p => p.Doctor).Include(p => p.Patient).Include(p => p.Prescription_Medicaments).ThenInclude(pM => pM.Medicament)
               .Where(p => p.IdPrescription == idPrescription)
               .Select(p => new GetPrescriptionInfoDTO
               {
                   IdPrescription = p.IdPrescription,
                   Date = p.Date,
                   DueDate = p.DueDate,
                   Doctor = new GetDoctorInfoDTO { FirstName = p.Doctor.FirstName, LastName = p.Doctor.LastName, Email = p.Doctor.Email },
                   Patient = new GetPatientInfoDTO { FirstName = p.Patient.FirstName, LastName = p.Patient.LastName, BirthDate = p.Patient.BirthDate },
                   Medicaments = p.Prescription_Medicaments.Select(pM => new GetMedicamentInfoDTO
                   {
                       Name = pM.Medicament.Name,
                       Descritpion = pM.Medicament.Descritpion,
                       Type = pM.Medicament.Type,
                       Dose = pM.Dose,
                       Details = pM.Details
                   }).ToList()
               }).FirstAsync();

        }

    }
}

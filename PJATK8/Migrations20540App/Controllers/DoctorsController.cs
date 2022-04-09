using Microsoft.AspNetCore.Mvc;
using Migrations20540App.InterFaces;
using Migrations20540App.Models.DTO.DTORequest;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations20540App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        private IDoctorDataBase _doctorDataBase;
        public DoctorsController(IDoctorDataBase doctorDataBase)
        {
            _doctorDataBase = doctorDataBase;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctorList = await _doctorDataBase.GetDoctors();
            if (!doctorList.Any())
                return NoContent();
            return Ok(doctorList);
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            try
            {
                return Ok(await _doctorDataBase.DeleteDoctor(idDoctor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDoctor(DoctorInfoDTO createDoctorDTO)
        {
            bool isAdded = await _doctorDataBase.AddNewDoctor(createDoctorDTO);
            if (!isAdded)
                return BadRequest("This doctor" + createDoctorDTO.FirstName + " " + createDoctorDTO.LastName + " is already in database");
            return Created("", $"Doctor: { createDoctorDTO.FirstName} { createDoctorDTO.LastName} has been added to database");
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> UpdateDoctor(DoctorInfoDTO createDoctorDTO, int idDoctor)
        {
            bool isUpdated = await _doctorDataBase.UpdateDoctor(createDoctorDTO, idDoctor);
            if (!isUpdated)
                return BadRequest($"The doctor with id {idDoctor} isn't in database");
            return Ok("The doctor has been updated");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Migrations20540App.InterFaces;
using System.Threading.Tasks;

namespace Migrations20540App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {

        private IPrescriptionDataBase _prescriptionDataBase;

        public PrescriptionController(IPrescriptionDataBase prescriptionDataBase)
        {
            _prescriptionDataBase = prescriptionDataBase;
        }

        [HttpGet("{idPrescription}")]
        public async Task<IActionResult> GetPrescription(int idPrescription)
        {
            var prescription = await _prescriptionDataBase.GetPrescription(idPrescription);
            if (prescription == null)
                return BadRequest("There is no data");
            return Ok(prescription);
        }
    }
}

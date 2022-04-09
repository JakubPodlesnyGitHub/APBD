using EntityFrameWorkCoreApp.Models;
using EntityFrameWorkCoreApp.Models.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private SqlService _SqlService;
        public TripController(s20540Context context)
        {
            _SqlService = new SqlService(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetTravelers()
        {
            var trips = await _SqlService.GetTravelers();
            if (!trips.Any())
                return Ok("No Data");
            return Ok(trips);
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AddNewClient(CreateClientAndTripRequestDTO requestDTO, int idTrip)
        {
            try
            {
                return Ok(await _SqlService.AddNewClient(requestDTO, idTrip));
            }
            catch (Exception e)
            {
                return BadRequest("Error: " + e.Message);
            }
        }
    }
}

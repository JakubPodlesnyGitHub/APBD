using EntityFrameWorkCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EntityFrameWorkCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private SqlService _SqlService;
        public ClientsController(s20540Context context)
        {
            _SqlService = new SqlService(context);
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteTraveler(int idClient)
        {
            int number = await _SqlService.DeleteTraveler(idClient);
            if (number == -1)
                return BadRequest("The client was not deleted because it was bound to another table");
            return Ok("The Client has been deleted: " + number);
        }
    }
}

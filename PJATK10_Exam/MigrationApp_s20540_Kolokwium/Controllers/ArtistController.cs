using Microsoft.AspNetCore.Mvc;
using MigrationApp_s20540_Kolokwium.InterFaces;
using MigrationApp_s20540_Kolokwium.Models;
using MigrationApp_s20540_Kolokwium.Models.DTO.Request;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        private IArtistDataBase _artistDataBase;
        private s20540DbContext _s20540DbContext;

        public ArtistController(IArtistDataBase artistDataBase, s20540DbContext s20540DbContext)
        {
            _artistDataBase = artistDataBase;
            _s20540DbContext = s20540DbContext;
        }
            
        [HttpGet("{idArtist}")]
        public async Task<IActionResult> GetArtist(int idArtist)
        {
            var artist = await _artistDataBase.GetArtist(idArtist);
            if (artist == null)
                return NoContent();
            return Ok(artist);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArtistTimePerformance(ArtistEventInfoDTO artistEventInfoDTO)
        {
            var val = await _artistDataBase.UpdateArtistTimePerformance(artistEventInfoDTO);
            if(val)
                return Ok($"Artist{artistEventInfoDTO.IdArtist}has been updated");
            return BadRequest($"Artist{artistEventInfoDTO.IdArtist}has not been updated");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MigrationApp_s20540_Kolokwium.InterFaces;
using MigrationApp_s20540_Kolokwium.Models;
using MigrationApp_s20540_Kolokwium.Models.DTO.Request;
using MigrationApp_s20540_Kolokwium.Models.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.Services
{
    public class ArtistService : IArtistDataBase
    {

        private s20540DbContext _s20540DbContext;

        public ArtistService(s20540DbContext s20540DbContext)
        {
            _s20540DbContext = s20540DbContext;
        }

        public async Task<GetArtistInfoDTO> GetArtist(int idArtist)
        {
            if (!await _s20540DbContext.Artists.AnyAsync(a => a.IdArtist == idArtist))
                return null;

            return await _s20540DbContext.Artists.Include(a => a.Artist_Events)
                .ThenInclude(aE => aE.Event)
                .Where(a => a.IdArtist == idArtist)
                .Select(a => new GetArtistInfoDTO
                {
                    IdArtist = a.IdArtist,
                    NickName = a.NickName,
                    EventsList = a.Artist_Events.Select(aE => new GetEventInfoDTO
                    {
                        IdEvent = aE.Event.IdEvent,
                        Name = aE.Event.Name,
                        StartDate = aE.Event.StartDate,
                        EndDate = aE.Event.EndDate
                    }).ToList()
                }).SingleAsync();
        }


        public async Task<bool> UpdateArtistTimePerformance(ArtistEventInfoDTO artistEventInfoDTO)
        {
            var artistEvent = await _s20540DbContext.Artist_Events.Where(aE => aE.IdArtist == artistEventInfoDTO.IdArtist && aE.IdEvent == artistEventInfoDTO.IdEvent).SingleAsync();
            var _event = await _s20540DbContext.Events.Where(e => e.IdEvent == artistEventInfoDTO.IdEvent).SingleAsync();
            var artist = await _s20540DbContext.Artists.Where(a => a.IdArtist == artistEventInfoDTO.IdArtist).SingleAsync();

            if (artistEvent.PerformanceDate > _event.StartDate)
                return false;

            artistEvent.PerformanceDate = artistEventInfoDTO.NewDateTimePerformance;
            await _s20540DbContext.SaveChangesAsync();
            return true;
        }
    }
}

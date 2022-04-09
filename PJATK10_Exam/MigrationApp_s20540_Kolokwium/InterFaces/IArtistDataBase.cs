using MigrationApp_s20540_Kolokwium.Models.DTO.Request;
using MigrationApp_s20540_Kolokwium.Models.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.InterFaces
{
    public interface IArtistDataBase
    {
        public Task<GetArtistInfoDTO> GetArtist(int idArtist);
        public Task<bool> UpdateArtistTimePerformance(ArtistEventInfoDTO artistEventInfoDTO);
    }
}

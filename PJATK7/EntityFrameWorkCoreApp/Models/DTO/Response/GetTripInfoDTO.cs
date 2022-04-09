using System;
using System.Collections.Generic;

namespace EntityFrameWorkCoreApp.Models.DTO.Response
{
    public class GetTripInfoDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }

        public IEnumerable<GetCountryInfoDTO> Countries;

        public IEnumerable<GetClinetInfoDTO> Clients;

    }
}

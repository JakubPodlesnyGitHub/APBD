﻿using System.Collections.Generic;

#nullable disable

namespace EntityFrameWorkCoreApp.Models
{
    public partial class Country
    {
        public Country()
        {
            CountryTrips = new HashSet<CountryTrip>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CountryTrip> CountryTrips { get; set; }
    }
}

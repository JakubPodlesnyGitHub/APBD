﻿using System;

#nullable disable

namespace EntityFrameWorkCoreApp.Models
{
    public partial class ClientTrip
    {
        public int IdClient { get; set; }
        public int IdTrip { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Trip IdTripNavigation { get; set; }
    }
}

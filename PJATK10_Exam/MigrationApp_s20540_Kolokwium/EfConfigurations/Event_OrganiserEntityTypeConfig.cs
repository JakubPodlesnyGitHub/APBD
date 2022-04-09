using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationApp_s20540_Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.EfConfigurations
{
    public class Event_OrganiserEntityTypeConfig : IEntityTypeConfiguration<Event_Organiser>
    {
        public void Configure(EntityTypeBuilder<Event_Organiser> builder)
        {
            builder.HasKey(eO => new { eO.IdEvent, eO.IdOrganiser });

            builder.HasOne(eO => eO.Event).WithMany(e => e.Event_Organisers).HasForeignKey(eO => eO.IdEvent);
            builder.HasOne(eO => eO.Organiser).WithMany(o => o.Event_Organisers).HasForeignKey(eO => eO.IdOrganiser);
        }
    }
}

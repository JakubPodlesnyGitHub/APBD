using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationApp_s20540_Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.EfConfigurations
{
    public class Artist_EventEntityTypeConfig : IEntityTypeConfiguration<Artist_Event>
    {
        public void Configure(EntityTypeBuilder<Artist_Event> builder)
        {
            builder.HasKey(aE => new { aE.IdArtist, aE.IdEvent });

            builder.Property(aE => aE.PerformanceDate).IsRequired();

            builder.HasOne(aE => aE.Artist).WithMany(a => a.Artist_Events).HasForeignKey(aE => aE.IdArtist);

            builder.HasOne(aE => aE.Event).WithMany(e => e.Artist_Events).HasForeignKey(aE => aE.IdEvent);
        }
    }
}

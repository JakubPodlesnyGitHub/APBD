using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationApp_s20540_Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.EfConfigurations
{
    public class ArtistEntityTypeConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(a => a.IdArtist);
            builder.Property(a => a.IdArtist).ValueGeneratedOnAdd();

            builder.Property(a => a.NickName).IsRequired().HasMaxLength(30);
        }

    }
}

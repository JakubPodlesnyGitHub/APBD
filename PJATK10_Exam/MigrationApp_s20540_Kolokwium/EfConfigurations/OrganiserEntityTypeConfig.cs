using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationApp_s20540_Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApp_s20540_Kolokwium.EfConfigurations
{
    public class OrganiserEntityTypeConfig : IEntityTypeConfiguration<Organiser>
    {
        public void Configure(EntityTypeBuilder<Organiser> builder)
        {
            builder.HasKey(o => o.IdOrganiser);
            builder.Property(o => o.IdOrganiser).ValueGeneratedOnAdd();

            builder.Property(o => o.OrganiserName).IsRequired().HasMaxLength(30);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Migrations20540App.Models;

namespace MigrationApps20540.EfConfigurations
{
    public class DoctorEntityTypeConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> opt)
        {
            opt.HasKey(e => e.IdDoctor);
            opt.Property(e => e.IdDoctor).ValueGeneratedOnAdd();

            opt.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            opt.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            opt.Property(e => e.Email).IsRequired().HasMaxLength(100);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationApps20540.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationApps20540.EfConfigurations
{
    public class Prescription_MedicamentEntityTypeConfig : IEntityTypeConfiguration<Prescription_Medicament>
    {
        void IEntityTypeConfiguration<Prescription_Medicament>.Configure(EntityTypeBuilder<Prescription_Medicament> opt)
        {
                opt.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
                //opt.Property(pm => new { pm.IdMedicament, pm.IdPrescription }).ValueGeneratedOnAdd();

                opt.Property(pm => pm.Details).IsRequired().HasMaxLength(100);

                opt.HasOne(pm => pm.Medicament).WithMany(m => m.Prescription_Medicaments).HasForeignKey(pm => pm.IdMedicament);
                opt.HasOne(pm => pm.Prescription).WithMany(p => p.Prescription_Medicaments).HasForeignKey(pm => pm.IdPrescription);
        }
    }
}

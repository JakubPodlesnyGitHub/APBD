using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Migrations20540App.Models;

namespace MigrationApps20540.EfConfigurations
{
    public class MedicamentEntityTypeConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> opt)
        {
            opt.HasKey(med => med.IdMedicament);
            opt.Property(med => med.IdMedicament).ValueGeneratedOnAdd();
            opt.Property(med => med.Name).IsRequired().HasMaxLength(100);
            opt.Property(med => med.Descritpion).IsRequired().HasMaxLength(100);
            opt.Property(med => med.Type).IsRequired().HasMaxLength(100);
        }
    }
}

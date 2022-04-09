using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Migrations20540App.Models;

namespace MigrationApps20540.EfConfigurations
{
    public class PatientEntityConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> opt)
        {
                opt.HasKey(p => p.IdPatient);
                opt.Property(p => p.IdPatient).ValueGeneratedOnAdd();

                opt.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
                opt.Property(p => p.LastName).IsRequired().HasMaxLength(100);
                opt.Property(p => p.BirthDate).IsRequired();
        }
    }
}

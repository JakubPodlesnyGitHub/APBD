using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Migrations20540App.Models;

namespace MigrationApps20540.EfConfigurations
{
    public class PrescriptionEntityTypeConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> opt)
        {
            opt.HasKey(e => e.IdPrescription);
            opt.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

            opt.Property(e => e.Date).IsRequired();
            opt.Property(e => e.DueDate).IsRequired();
            opt.Property(e => e.IdDoctor).IsRequired();

            opt.HasOne(p => p.Doctor).WithMany(d => d.DoctorPrescriptions).HasForeignKey(p => p.IdDoctor);
            opt.HasOne(p => p.Patient).WithMany(pa => pa.PatientPrescriptions).HasForeignKey(p => p.IdPatient);
        }
    }
}

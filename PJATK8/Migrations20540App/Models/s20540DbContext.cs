using Microsoft.EntityFrameworkCore;
using MigrationApps20540.EfConfigurations;
using MigrationApps20540.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations20540App.Models
{
    public class s20540DbContext : DbContext
    {
        public s20540DbContext()
        {

        }
        public s20540DbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new PatientEntityConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new MedicamentEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new Prescription_MedicamentEntityTypeConfig());

            modelBuilder.Entity<Doctor>(opt =>
            {
                opt.HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Jakub", LastName = "Komorowski", Email = "cos@cos.pl" },
                    new Doctor { IdDoctor = 2, FirstName = "Magda", LastName = "Romanowska", Email = "cos123@dsa.pl" },
                    new Doctor { IdDoctor = 3, FirstName = "Marysia", LastName = "Wasilewska", Email = "kotek123@cdass.pl" }
                    );
            });

            modelBuilder.Entity<Patient>(opt =>
            {
                opt.HasData(
                    new Patient { IdPatient = 1, FirstName = "Ala", LastName = "Chryniecka", BirthDate = new DateTime(2000, 12, 31, 5, 10, 20) },
                new Patient { IdPatient = 2, FirstName = "Tomasz", LastName = "Tolak", BirthDate = new DateTime(1999, 5, 26, 5, 10, 20) },
                new Patient { IdPatient = 3, FirstName = "Katarzyna", LastName = "Mykhalkiv", BirthDate = new DateTime(2001, 11, 6, 5, 10, 20) });
            });

            modelBuilder.Entity<Prescription>(opt =>
            {
                opt.HasData(
                    new Prescription { IdPrescription = 1, Date = new DateTime(2019, 12, 31, 5, 10, 20), DueDate = new DateTime(2020, 12, 31, 5, 10, 20), IdPatient = 1, IdDoctor = 1 },
                new Prescription { IdPrescription = 2, Date = new DateTime(2015, 12, 31, 5, 10, 20), DueDate = new DateTime(2016, 12, 31, 5, 10, 20), IdPatient = 2, IdDoctor = 2 },
                new Prescription { IdPrescription = 3, Date = new DateTime(2020, 12, 31, 5, 10, 20), DueDate = new DateTime(2001, 12, 31, 5, 10, 20), IdPatient = 3, IdDoctor = 3 });
            });

            modelBuilder.Entity<Medicament>(opt =>
            {
                opt.HasData(
                    new Medicament { IdMedicament = 1, Name = "Rutinoscorbin", Descritpion = "tabletka laktoza", Type = "AAA" },
                new Medicament { IdMedicament = 2, Name = "Claritine", Descritpion = "Alergicy są grupa narazona na wzmozona sennosc", Type = "BBB" },
                new Medicament { IdMedicament = 3, Name = "Ibuprom", Descritpion = "Tabletka powlekana Ibuprom zawiera 200 mg ibuprofenu.", Type = "CCC" });
            });

            modelBuilder.Entity<Prescription_Medicament>(opt =>
            {
                opt.HasData(
                    new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 20, Details = "Dzienie" },
                new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 3, Details = "Tygodniowo" },
                new Prescription_Medicament { IdMedicament = 3, IdPrescription = 3, Dose = 4, Details = "Dziennie" });
            });

        }
    }
}

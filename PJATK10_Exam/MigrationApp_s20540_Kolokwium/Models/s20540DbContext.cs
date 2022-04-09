using Microsoft.EntityFrameworkCore;
using MigrationApp_s20540_Kolokwium.EfConfigurations;
using System;

namespace MigrationApp_s20540_Kolokwium.Models
{
    public class s20540DbContext : DbContext
    {

        public s20540DbContext()
        {

        }
        public s20540DbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Organiser> Organisers { get; set; }

        public DbSet<Event> Events { get; set; }
        
        public DbSet<Artist_Event> Artist_Events { get; set; }

        public DbSet<Event_Organiser> Event_Organisers { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArtistEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new OrganiserEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new Artist_EventEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new Event_OrganiserEntityTypeConfig());


            modelBuilder.Entity<Artist>(opt =>
            {
                opt.HasData(new Artist { IdArtist = 1, NickName = "Banksy"},
                    new Artist { IdArtist = 2,NickName = "Kat123"}
                    );
            });

            modelBuilder.Entity<Event>(opt => {
                opt.HasData(new Event { IdEvent = 1, Name = "Bal Maturalny", StartDate = new DateTime(2000, 12, 31, 5, 10, 20), EndDate = new DateTime(2001, 12, 31, 5, 10, 20) },
                    new Event { IdEvent =2,Name = "Wesele",StartDate = new DateTime(2019, 12, 31, 5, 10, 20) ,EndDate = new DateTime(2019, 12, 31, 5, 10, 20) }
                    );
            });

            modelBuilder.Entity<Organiser>(opt => {
                opt.HasData(new Organiser { IdOrganiser = 1, OrganiserName = "Fimra123" },
                    new Organiser { IdOrganiser =2, OrganiserName = "123Firma"}
                    );
            });

            modelBuilder.Entity<Event_Organiser>(opt =>
            {
                opt.HasData(new Event_Organiser { IdEvent = 1, IdOrganiser = 1 },
                    new Event_Organiser { IdEvent = 2, IdOrganiser =2}
                    );
            });

            modelBuilder.Entity<Artist_Event>(opt =>
            {
                opt.HasData(new Artist_Event { IdArtist = 1 ,IdEvent = 1,PerformanceDate = new DateTime(2000, 12, 31, 5, 10, 20) },
                    new Artist_Event { IdArtist =2,IdEvent =2, PerformanceDate = new DateTime(2000, 12, 31, 5, 10, 20) }
                    );
            });
        }
    }
}

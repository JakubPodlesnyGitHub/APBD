using MigrationApps20540.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations20540App.Models
{
    public class Medicament
    {
        public int IdMedicament { get; set; }

        public string Name { get; set; }

        public string Descritpion { get; set; }

        public string Type { get; set; }

        public ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }

    }
}

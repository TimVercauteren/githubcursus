using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Plant
    {
        public Plant(int id, string naam, string kleur, decimal prijs, string soort)
        {
            this.PlantId = id;
            this.PlantenNaam = naam;
            this.Kleur = kleur;
            this.Prijs = prijs;
            this.Soort = soort;
        }
        public int PlantId { get; set; }
        public string PlantenNaam { get; set; }
        public string Kleur { get; set; }
        public decimal Prijs { get; set; }
        public string Soort { get; set; }

        public override string ToString()
        {
            return PlantenNaam; 
        }
    }
}

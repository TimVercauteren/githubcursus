using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Brouwer
    {
        public int BrouwerNr { get; set; }
        public string BrouwerNaam { get; set; }
        public bool isBelgisch { get; set; }
        public List<Bier> Bieren { get; set; }
        public override string ToString()
        {
            return "Brouwerij " + BrouwerNaam + " ( " + (isBelgisch ? "Belgisch" : "Niet Belgisch") + " ) ";
        }
    }
}
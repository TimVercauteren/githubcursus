using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Persoon
    {
        public string Naam { get; set; }
        public int AantalKinderen { get; set;}

        public Persoon()
        {
        }
        public Persoon(string naam)
        {
            Naam = naam;
        }
        public Persoon(string naam, int aantalKinderen)
        {
            Naam = naam;
            AantalKinderen = aantalKinderen;
        }
    }
}

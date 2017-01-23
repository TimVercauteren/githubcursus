using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Klant
    {
        public Klant(string voornaam, string naam)
        {
            this.Familienaam = naam;
            this.Voornaam = voornaam;
        }
        private string voornaamValue;

        public string Voornaam
        {
            get
            {
                return voornaamValue;
            }
            set
            {
                voornaamValue = value;
            }
        }
        private string familienaamValue ;

        public string Familienaam
        {
            get
            {
                return familienaamValue;
            }
            set
            {
                familienaamValue = value;
            }
        }
        public void Afbeelden()
        {
            Console.WriteLine("Klant: {0} {1}", Voornaam, Familienaam);
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", Voornaam, Familienaam);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Afdeling
    {
        public const int Verdiepingen = 10;
        public Afdeling(string naam, int verdieping)
        {
            this.Naam = naam;
            this.Verdieping = verdieping;
        }

        private string naamValue;

        public string Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                naamValue = value;
            }
        }
        private int verdiepingValue;

        public int Verdieping
        {
            get {
                return verdiepingValue;
            }
            set
            {
                if (value >=0 && value <= Verdiepingen)
                verdiepingValue = value;
            }
        }
        public override string ToString()
        {
            return String.Format("Afdeling {0} op verdieping {1}", this.Naam, this.Verdieping);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Arbeider : Werknemer
    {
        public Arbeider(String naam, DateTime inDienst, Geslacht geslacht,
            decimal uurloon, byte ploegenstelsel)
            : base(naam, inDienst, geslacht)
        {
            this.Uurloon = uurloon;
            this.Ploegenstelsel = ploegenstelsel;
        }

        private decimal uurloonValue;
        public override decimal Premie
        {
            get
            {
                return Uurloon * 150m;
            }
        }

        public decimal Uurloon
        {
            get { return uurloonValue; }
            set
            {
                if (value >= 0m)
                uurloonValue = value;
            }
        }
        private byte ploegenstelselValue;

        public byte Ploegenstelsel
        {
            get { return ploegenstelselValue; }
            set
            {
                if (value >= 1 && value <= 3)
                ploegenstelselValue = value;
            }
        }

        public override decimal Bedrag
        {
            get
            {
                return Uurloon * 2000;
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Uurloon: {0}", Uurloon);
            Console.WriteLine("Ploegenstelsel: {0}", Ploegenstelsel);
            Console.WriteLine("");
        }
        public override string ToString()
        {
            return base.ToString() + ' ' + Uurloon + "Euro/uur";
        }
    }
}

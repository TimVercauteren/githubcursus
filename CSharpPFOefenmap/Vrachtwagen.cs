using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Vrachtwagen : Voertuig
    {
        public Vrachtwagen(string polisnummer, decimal prijs, int aantalPk, float verbruik,
            string nummerplaat, float maxLading = 10000f)
            : base (polisnummer, prijs, aantalPk, verbruik, nummerplaat)
        {
            this.MaxLading = maxLading;
        }

        private float maxLadingValue;

        public float MaxLading
        {
            get
            {
                return maxLadingValue;
            }
            set
            {
                if (value >= 0)
                maxLadingValue = value;
            }
        }
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Maximum Lading: {0}", MaxLading);
        }
        public override double GetKyotoScore()
        {
            return (this.GemiddeldVerbruik * this.Pk / this.MaxLading);
        }

        public override double GeefVervuiling()
        {
            return this.GetKyotoScore() * 20;
        }
    }
}

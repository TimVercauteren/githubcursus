using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Personenwagen : Voertuig
    {
        public Personenwagen(string polisnummer, decimal kostprijs, int aantalPk, float verbruik,
            string nummerplaat, int aantalPersonenen, int aantalDeuren)
            : base(polisnummer, kostprijs, aantalPk, verbruik, nummerplaat)
        {
            this.AantalDeuren = aantalDeuren;
            this.AantalPersonenen = aantalPersonenen;
        }
        private int aantalPersonenValue;

        public int AantalPersonenen
        {
            get
            {
                return aantalPersonenValue;
            }
            set
            {
                if (value >= 1 && value <= 9)
                    aantalPersonenValue = value;
            }
        }

        private int deurenValue;

        public int AantalDeuren
        {
            get
            {
                return deurenValue;
            }
            set
            {
                if (value >=2 && value <= 5)
                deurenValue = value;
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Aantal deuren:{0}\nMax aantal personene: {1}", AantalDeuren, AantalPersonenen);
        }
        public override double GetKyotoScore()
        {
            return (this.GemiddeldVerbruik * this.Pk / this.AantalDeuren);
        }
        public override double GeefVervuiling()
        {
            return this.GetKyotoScore() * 5;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public abstract class Voertuig : IVervuiler, IMilieu, IPrivaat
    {
        private string polisValue;
        private decimal kostValue;
        private int pkValue;
        private float verbruikValue;
        private string nummerPlaatValue;
        public Voertuig(string polisnummer, decimal prijs, int  aantalPk, float verbruik, string nummerplaat)
        {
            this.PolisHouder = polisnummer;
            this.KostPrijs = prijs;
            this.Pk = aantalPk;
            this.GemiddeldVerbruik = verbruik;
            this.Nummerplaat = nummerplaat;
        }
        public Voertuig(): this(polisnummer: "onbepaald", prijs: 0m, aantalPk: 0, verbruik: 0, nummerplaat: "onbepaald")
        {

        }
        public abstract double GetKyotoScore();
        public virtual void Afbeelden()
        {
            Console.WriteLine("\nOVERZICHT WAGEN");
            LijnenTrekker.TrekLijn();
            Console.WriteLine("Polisnummer: {0}\nPrijs: {1}\nPk: {2}\nGemiddeld verbruik: {3}\nNummerplaat: {4}",
                this.PolisHouder, this.KostPrijs, this.Pk, this.GemiddeldVerbruik, this.Nummerplaat);
        }
        public abstract double GeefVervuiling();
        public string GeefMilieuData()
        {
            return String.Format("Pk: {0}\nKostprijs: {1}\nVerbruik{2}",
                Pk, KostPrijs, GemiddeldVerbruik);
        }
        public string GeefPrivateData()
        {
            return String.Format("Naam: {0}\nNummerplaat: {1}",PolisHouder,Nummerplaat);
        }

        public string Nummerplaat
        {
            get
            {
                return nummerPlaatValue;
            }
            set
            {
                nummerPlaatValue = value;
            }
        }

        public float GemiddeldVerbruik
        {
            get
            {
                return verbruikValue;
            }
            set
            {
                if (value>=0f)
                verbruikValue = value;
            }
        }

        public int Pk
        {
            get
            {
                return pkValue;
            }
            set
            {
                if (value>=0)
                pkValue = value;
            }
        }


        public decimal KostPrijs
        {
            get
            {
                return kostValue;
            }
            set
            {
                if (value >=0m)
                kostValue = value;
            }
        }


        public string PolisHouder
        {
            get
            {
                return polisValue;
            }
            set
            {
                polisValue = value;
            }
        }

    }
}

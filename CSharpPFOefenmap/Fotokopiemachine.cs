using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Materiaal
{
    public delegate void Onderhoudsbeurt(Fotokopiemachine machine);
    public class Fotokopiemachine : IKost
    {
        private const int AantalBlzTussen2OnderhoudsBeurten = 10;
        public Fotokopiemachine(string serienummer, int aantalBlz, decimal kostPerBlz)
        {
            this.Serienummer = serienummer;
            this.AantalBlz = aantalBlz;
            this.KostPerBlz = kostPerBlz;
        }
        public class KostPerBlzException : Exception
        {
            public KostPerBlzException(string message, decimal verkeerdekost)
                : base(message)
            {
                VerkeerdeKost = verkeerdekost;
            }
            private decimal verkeerdeKostValue;
            public decimal VerkeerdeKost
            {
                get
                {
                    return verkeerdeKostValue;
                }
                set
                {
                    verkeerdeKostValue = value;
                }
            }

        }
        public class AantalBlzException : Exception
        {
            public AantalBlzException( string message, int verkeerdAantalBlz)
                : base(message)
            {
                VerkeerdeAantalBlz = verkeerdAantalBlz;
            }
            private int verkeerdAantalBlzValue;
            public int VerkeerdeAantalBlz
            {
                get
                {
                    return verkeerdAantalBlzValue;
                }
                set
                {
                    verkeerdAantalBlzValue = value;
                }
            }
        }
        
        private string serienrValue;
        public string Serienummer
        {
            get
            {
                return serienrValue;
            }
            set
            {
                serienrValue = value;
            }
        }

        private int aantalBlzValue;
        public int AantalBlz
        {
            get
            {
                return aantalBlzValue;
            }
            set
            {
                if (value < 0)
                    throw new AantalBlzException("Aantal blz. kleiner dan 0!", value);
                aantalBlzValue = value;
            }
        }

        private decimal kostPerBlzValue;
        public decimal KostPerBlz
        {
            get
            {
                return kostPerBlzValue;
            }
            set
            {
                if (value < 0)
                    throw new KostPerBlzException("Kost per blz. kleiner of gelijk aan 0!", value);
                kostPerBlzValue = value;
            }
        }

        public decimal Bedrag
        {
            get
            {
                return AantalBlz*KostPerBlz;
            }
        }

        public bool Menselijk
        {
            get
            {
                return false;
            }
        }
        public event Onderhoudsbeurt OnderhoudNodig;
        public void Fotokopieer (int aantalBlz)
        {
            for (int i=1;i<= aantalBlz; i++)
            {
                Console.WriteLine("Fotokopiemachine {0} kopeert blz. {1} van {2}.", this.Serienummer,
                    i, aantalBlz);
                if (++AantalBlz % AantalBlzTussen2OnderhoudsBeurten == 0)
                {
                    if (OnderhoudNodig != null)
                    {
                        OnderhoudNodig(this);
                    }
                }
            }
        }
    }
}

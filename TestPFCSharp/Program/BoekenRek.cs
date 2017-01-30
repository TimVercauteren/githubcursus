using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class BoekenRek : IVoorwerpen
    {
        public BoekenRek(int hoogte, int breedte, decimal aankoopprijs)
        {
            HoogteInCm = hoogte;
            BreedteInCm = breedte;
            AankoopPrijs = aankoopprijs;
        }

        private decimal aankoopPrijsValue;
        public decimal AankoopPrijs
        {
            get
            {
                return aankoopPrijsValue;
            }
            set
            {
                if (value <= 0)
                    throw new KostPrijsException("De prijs kan niet negatief of nul zijn!", value);
                aankoopPrijsValue = value;
            }
        }

        private int hoogteInCmValue;
        public int HoogteInCm
        {
            get
            {
                return hoogteInCmValue;
            }
            set
            {
                if (value < 0)
                    throw new AfmetingException("De hoogte kan niet negatief zijn!", value);
                hoogteInCmValue = value;
            }
        }

        private int breedteInCmValue;
        public int BreedteInCm
        {
            get
            {
                return breedteInCmValue;
            }
            set
            {
                if (value < 0)
                    throw new AfmetingException("De breedte kan niet negatief zijn!", value);
                breedteInCmValue = value;
            }
        }
        public decimal Winst
        {
            get
            {
                return AankoopPrijs * 2m;
            }
        }

        public void GegevensTonen()
        {
            Console.WriteLine("Info boekenrek");
            Console.WriteLine("--------------");
            Console.WriteLine("Afmetingen boekenkast: {0} cm x {1} cm.\nAankoopprijs: {2}",
                BreedteInCm, HoogteInCm, AankoopPrijs);
            Console.WriteLine();
        }

        public class AfmetingException : Exception
        {
            public AfmetingException(string message, int verkeerdeAfmeting)
                : base(message)
            {
                VerkeerdeAfmeting = verkeerdeAfmeting;
            }
            private int verkeerdeAfmetingValue;
            public int VerkeerdeAfmeting
            {
                get
                {
                    return verkeerdeAfmetingValue;
                }
                set
                {
                    verkeerdeAfmetingValue = value;
                }
            }
        }
    }
}

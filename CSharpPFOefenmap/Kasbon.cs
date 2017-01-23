using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Kasbon : ISpaarmiddel
    {
        public Kasbon(DateTime aankoopDatum, decimal bedrag, int looptijd,
            float intrest, Klant eigenaar)
        {
            this.Aankoopdatum = aankoopDatum;
            this.Bedrag = bedrag;
            this.Looptijd = looptijd;
            this.Intrest = intrest;
            this.Eigenaar = eigenaar;
        }
        public class AankoopDatumException : Exception
        {
            public AankoopDatumException(string message, DateTime fouteDatum)

            : base(message)
            {
                FouteAankoopDatum = fouteDatum;
            }
            private DateTime fouteAankoopDatumValue;
            public DateTime FouteAankoopDatum
            {
                get
                {
                    return fouteAankoopDatumValue;
                }
                set
                {
                    fouteAankoopDatumValue = value;
                }
            }

        }
        public class BedragException : Exception
        {
            public BedragException(string message, decimal foutBedrag)
                : base(message)
            {
                FoutBedrag = foutBedrag;
            }
            private decimal foutBedragValue;

            public decimal FoutBedrag
            {
                get
                {
                    return foutBedragValue;
                }
                set
                {
                    foutBedragValue = value;
                }
            }

        }
        public class LooptijdException : Exception
        {
            public LooptijdException(string message, int looptijdFout)
            {
                LooptijdFout = looptijdFout;
            }
            private int looptijdFoutValue;
            public int LooptijdFout
            {
                get
                {
                    return looptijdFoutValue;
                }
                set
                {
                    looptijdFoutValue = value;
                }
            }

        }
        public class IntrestException : Exception
        {
            public IntrestException(string message, float intrestFout)
                : base(message)
            {
                IntrestFout = intrestFout;
            }
            private float intrestFoutValue;
            public float IntrestFout
            {
                get
                {
                    return intrestFoutValue;
                }
                set
                {
                    intrestFoutValue = value;
                }
            }

        }
        private static readonly DateTime minJaar = new DateTime(1900,1,1);

        private DateTime aankoopDatumValue;
        public DateTime Aankoopdatum
        {
            get
            {
                return aankoopDatumValue;
            }
            set
            {
                if (value < minJaar)
                    throw new AankoopDatumException("De kasbon heeft een verkeerde Aankoopdatum!", value);
                aankoopDatumValue = value;
            }
        }

        private decimal bedragValue;
        public decimal Bedrag
        {
            get
            {
                return bedragValue;
            }
            set
            {
                if (value < 0)
                    throw new BedragException("De kasbon moet een positieve waarde hebben!", value);
                bedragValue = value;
            }
        }

        private int looptijdValue;
        public int Looptijd
        {
            get
            {
                return looptijdValue;
            }
            set
            {
                if (value < 0)
                    throw new LooptijdException("De looptijd in jaren kan geen negatief getal zijn!", value);
                looptijdValue = value;
            }
        }

        private float intrestValue;
        public float Intrest
        {
            get
            {
                return intrestValue;
            }
            set
            {
                if (value < 0)
                    throw new IntrestException("De intrest mag geen negatief getal zijn!", value);
                intrestValue = value;
            }
        }

        private Klant eigenaarValue;
        public Klant Eigenaar
        {
            get
            {
                return eigenaarValue;
            }
            set
            {
                eigenaarValue = value;
            }
        }

        public void Afbeelden()
        {
            Console.WriteLine("KASBON");
            LijnenTrekker.TrekLijn();
            Console.WriteLine("Eigenaar: {0}\nBedrag: {1}\nLooptijd: {2}\nIntrest: {3}\nAankoopdatum: {4}",
                Eigenaar, Bedrag, Looptijd, Intrest, Aankoopdatum);
        }
    }
}

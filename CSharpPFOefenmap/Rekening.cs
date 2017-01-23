using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public delegate void Transactie(Rekening rekening);
    public abstract class Rekening : ISpaarmiddel
    {
        private readonly DateTime EersteCreatie = new DateTime(1900, 1, 1);
        public Rekening(string nummer, Klant eigenaar, decimal saldo = 0m)
        {
            this.RekeningNummer = nummer;
            this.Saldo = saldo;
            this.CreatieDatum = DateTime.Today;
            this.Eigenaar = eigenaar;
        }
        public class RekeningCreatieException : Exception
        {
            public RekeningCreatieException(string message, DateTime datum)
                : base(message)
            {
                CreatieDatumFout = datum;
            }
            private DateTime creatieDatumFoutValue;
            public DateTime CreatieDatumFout
            {
                get
                {
                    return creatieDatumFoutValue;
                }
                set
                {
                    creatieDatumFoutValue = value;
                }
            }

        }
        public class RekeningnummerException : Exception
        {
            public RekeningnummerException(string message, string rekeningnummerFout)
                : base(message)
            {
                RekeningnummerFout = rekeningnummerFout;
            }
            private string rekeningnummerFoutValue;
            public string RekeningnummerFout
            {
                get
                {
                    return rekeningnummerFoutValue;
                }
                set
                {
                    rekeningnummerFoutValue = value;
                }
            }
        }

        private DateTime creatieDatumValue;
        public DateTime CreatieDatum
        {
            get { return creatieDatumValue; }
            set
            {
                if (value < EersteCreatie)
                    throw new RekeningCreatieException("Fout! Rekeningdatum voor 1/1/1900!", value);
                creatieDatumValue = value; 
            }
        }

        private decimal saldoValue;
        public decimal Saldo
        {
            get
            {
                return saldoValue;
            }
            set
            {
                saldoValue = value;
            }
        }

        private string rekeningNummerValue;
        public string RekeningNummer
        {
            get
            {
                return rekeningNummerValue;
            }
            set
            {
                if (!ControleerRekening(value))
                    throw new RekeningnummerException("Fout! Rekeningnummer klopt niet!", value);
                rekeningNummerValue = value;
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

        private decimal vorigSaldoValue;
        public decimal VorigSaldo
        {
            get
            {
                return vorigSaldoValue;
            }
            set
            {
                vorigSaldoValue = value;
            }
        }


        private bool ControleerRekening(string rekening)
        {
            int laatste, brol;
            ulong test;
            if (rekening == string.Empty)
            {
                return false;
            }
            else if (rekening.Substring(0, 2) == "BE")
            {
                if (int.TryParse(rekening.Substring(2, 2), out brol))
                {
                    if (ulong.TryParse(rekening.Substring(4, 10), out test) && int.TryParse(rekening.Substring(rekening.Length - 2, 2), out laatste))
                    {
                        if ((int)(test % 97) == laatste)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        public virtual void Afbeelden()
        {
            Console.WriteLine("\nEIGENSCHAPPEN REKENING");
            LijnenTrekker.TrekLijn(30);
            Console.WriteLine("Rekeningnummer: {0}", RekeningNummer);
            Console.WriteLine("Saldo: {0}", Saldo);
            Console.WriteLine("Datum Creatie: {0}", CreatieDatum);
            Eigenaar.Afbeelden();
        }
        public void Storten(decimal bedrag)
        {
            VorigSaldo = Saldo;
            Saldo += bedrag;
            if (RekeningsUitreksel != null)
            {
                RekeningsUitreksel(this);
            }
        }
        public virtual void Afhalen(decimal bedrag)
        {
            VorigSaldo = Saldo;
            if (Saldo >= bedrag)
            {
                Saldo -= bedrag;
                if (RekeningsUitreksel != null)
                {
                    RekeningsUitreksel(this);
                }
            }
            else
            {
                if (SaldoInHetRood != null)
                {
                    SaldoInHetRood(this);
                }
            }
        }
        public event Transactie RekeningsUitreksel;
        public event Transactie SaldoInHetRood;
    }
}

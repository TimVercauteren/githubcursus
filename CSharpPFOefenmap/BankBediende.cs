using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class BankBediende
    {
        public BankBediende(string naam, string voornaam)
        {
            Naam = naam;
            Voornaam = voornaam;
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
        public void UitrekselTonen(Rekening rekening)
        {
            Console.WriteLine("Rekening Nummer: {0}\nRekening houder: {1}", rekening.RekeningNummer, rekening.Eigenaar);
            Console.WriteLine("Vorig Saldo: {0}", rekening.VorigSaldo);
            Console.WriteLine("Bedrag: {0}", Math.Abs(rekening.Saldo - rekening.VorigSaldo));
            Console.WriteLine("Saldo: {0}", rekening.Saldo);
        }
        public void SaldoInHetRood(Rekening rekening)
        {
            Console.WriteLine("Helaas! U heeft niet genoeg geld op uw rekening om deze verrichting te doen");
            Console.WriteLine("Maximu af te halen bedrag: {0} euro", rekening.Saldo);
        }
    }
}

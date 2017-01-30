using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class WoordenBoek : Boek
    {
        public WoordenBoek(string titel, Persoon auteur, decimal aankoopprijs,
            Genre genre, string taal) : base(titel, auteur, aankoopprijs, genre)
        {
            Taal = taal;
        }

        private string taalValue;
        public string Taal
        {
            get
            {
                return taalValue;
            }
            set
            {
                taalValue = value;
            }
        }


        public override decimal Winst
        {
            get
            {
                return AankoopPrijs * 1.75m;
            }
        }

        public override void GegevensTonen()
        {
            base.GegevensTonen();
            Console.WriteLine("Taal: {0}", Taal);
            Console.WriteLine();
        }
    }
}

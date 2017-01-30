using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class LeesBoek : Boek
    {
        public LeesBoek(string titel, Persoon auteur, decimal aankoopprijs,
            Genre genre, string onderwerp) : base (titel, auteur, aankoopprijs, genre)
        {
            Onderwerp = onderwerp;
        }

        private string onderwerpValue;
        public string Onderwerp
        {
            get
            {
                return onderwerpValue;
            }
            set
            {
                onderwerpValue = value;
            }
        }
        public override decimal Winst
        {
            get
            {
                return AankoopPrijs * 1.5m;
            }
        }
        public override void GegevensTonen()
        {
            base.GegevensTonen();
            Console.WriteLine("Onderwerp: {0}", Onderwerp);
            Console.WriteLine();
        }
    }
}

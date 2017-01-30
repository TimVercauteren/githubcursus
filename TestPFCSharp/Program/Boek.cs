using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public abstract class Boek : IVoorwerpen
    {
        public Boek (string titel, Persoon auteur, decimal aankoopprijs,
            Genre genre)
        {
            Titel = titel;
            Auteur = auteur;
            AankoopPrijs = aankoopprijs;
            Genre = genre;
        }

        private static Persoon eigenaarValue;
        public static Persoon Eigenaar
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

        private Genre genreValue;
        public Genre Genre
        {
            get
            {
                return genreValue;
            }
            set
            {
                genreValue = value;
            }
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
                if (value < 0)
                    throw new KostPrijsException("De prijs van een boek kan niet negatief of nul zijn!", value);
                aankoopPrijsValue = value;
            }
        }

        private Persoon auteurValue;
        public Persoon Auteur
        {
            get
            {
                return auteurValue;
            }
            set
            {
                auteurValue = value;
            }
        }

        private string titelValue;
        public string Titel
        {
            get
            {
                return titelValue;
            }
            set
            {
                titelValue = value;
            }
        }

        public abstract decimal Winst { get; }

        public virtual void GegevensTonen()
        {
            Console.WriteLine("Boekfiche:");
            Console.WriteLine("----------");
            Console.WriteLine("Titel: {0}\nAuteur: {1}\nEigenaar: {2}\nAankoopprijs: {3} EUR\n{4}",
                Titel, Auteur.ToString(), Eigenaar.ToString(), AankoopPrijs, Genre.ToString());
        }
    }
}

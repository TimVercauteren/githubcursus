using System;

namespace Program
{
    public class Genre
    {
        public Genre (string naam, DoelGroep doel)
        {
            Naam = naam;
            DoelGr = doel;
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
                //Exception ?
                naamValue = value;
            }
        }

        private DoelGroep doelGroepValue;

        public DoelGroep DoelGr
        {
            get
            {
                return doelGroepValue;
            }
            set
            {
                doelGroepValue = value;
            }
        }
        public class DoelGroep
        {
            public DoelGroep(int leeftijd)
            {
                this.LeeftijdMinimum = leeftijd;
            }
            public enum BoekCategorie
            {
                Jeugd,
                Volwassen
            }

            private int leeftijdMinimumValue;
            public int LeeftijdMinimum
            {
                get
                {
                    return leeftijdMinimumValue;
                }
                set
                {
                    if (value < 0 || value > 120)
                        throw new Exception("Opgegeven leeftijd klopt niet!");
                    leeftijdMinimumValue = value;
                }
            }

            public BoekCategorie Categorie
            {
                get
                {
                    if (LeeftijdMinimum < 18)
                        return BoekCategorie.Jeugd;
                    else
                        return BoekCategorie.Volwassen;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Genre: {0}\nDoelgroep: {1}", Naam, DoelGr.Categorie);
        }

    }
}
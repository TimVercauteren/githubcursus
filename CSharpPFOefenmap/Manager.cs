using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public sealed class Manager : Bediende
    {
        public Manager(string naam, DateTime inDienst, Geslacht geslacht, decimal wedde, decimal bonus)
            : base (naam, inDienst, geslacht, wedde)
        {
            Bonus = bonus;
        }
        private decimal bonusValue;

        public override decimal Premie
        {
            get
            {
                return Bonus * 2m;
            }
        }
        public decimal Bonus
        {
            get
            {
                return bonusValue;
            }
            set
            {
                if(value >=0m)
                bonusValue = value;
            }
        }
        public override decimal Bedrag
        {
            get
            {
                return base.Bedrag + Bonus;
            }
        }
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Bonus: {0}", Bonus);
        }
        public override string ToString()
        {
            return base.ToString() + " Bonus: " + Bonus;
        }
        public void OnderhoudNoteren(Firma.Materiaal.Fotokopiemachine machine)
        {
            Console.WriteLine("{0} registreert het onderhoud van machine {1} in het logboek",
                Naam, machine.Serienummer);
        }
    }
}

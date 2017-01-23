﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Bediende : Werknemer
    {
        public Bediende(string naam, DateTime inDienst, Geslacht geslacht, decimal wedde)
            : base (naam, inDienst, geslacht)
        {
            this.Wedde = wedde;
        }
        private decimal weddeValue;
        public override decimal Premie
        {
            get
            {
                return Wedde * 2m;
            }
        }

        public decimal Wedde
        {
            get
            {
                return weddeValue;
            }
            set
            {
                if (value>0m)
                weddeValue = value;
            }
        }
        public override decimal Bedrag
        {
            get
            {
                return Wedde * 12;
            }
        }
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Wedde: {0}", Wedde);
        }
        public override string ToString()
        {
            return base.ToString() + ' ' + Wedde + " Loon";
        }
        public void DoeOnderhoud(Firma.Materiaal.Fotokopiemachine machine)
        {
            Console.WriteLine("{0} onderhoudt machine {1}", Naam, machine.Serienummer);
        }

    }
}

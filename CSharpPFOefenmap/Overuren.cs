using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Overuren
    {
        private int[] overurenValue = new int [12];
        private static readonly string[] maanden = {"jan", "feb", "maa", "apr", "jun", "jul",
            "aug", "sep", "okt", "nov", "dec"};

        public int this [int maand]
        {
            get
            {
                return overurenValue[maand]; 
            }
            set
            {
                overurenValue[maand] = value;
            }
        }
        public int this[string maand]
        {
            get
            {
                return overurenValue[WelkeMaand(maand)];
            }
            set
            {
                overurenValue[WelkeMaand(maand)] = value;
            }
        }
        public int WelkeMaand(string maand)
        {
            int maandNr = Array.IndexOf(maanden, maand);
            if (maandNr == -1)
                throw new IndexOutOfRangeException("Ongeldige maand:" + maand);
            return maandNr;
        }
        public int Totaal
        {
            get
            {
                int totaal = 0;
                foreach (int overuur in overurenValue)
                    totaal += overuur;
                return totaal;
            }
        }
    }
}

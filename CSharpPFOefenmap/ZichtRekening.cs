using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Zichtrekening : Rekening
    {
        public Zichtrekening(string nummer, decimal maxKrediet, Klant eigenaar, decimal saldo)
            : base (nummer, eigenaar, saldo)
        {
            this.MaxKrediet = maxKrediet;
        }
        public class KredietWaardeException : Exception
        {
            public KredietWaardeException(string message, decimal waardeFout)
                : base(message)
            {
                this.KredietWaardeFout = waardeFout;
            }
            private decimal kredietWaardeFoutValue;
            public decimal KredietWaardeFout
            {
                get
                {
                    return kredietWaardeFoutValue;
                }
                set
                {
                    kredietWaardeFoutValue = value;
                }
            }
        }
        private decimal maxKredietValue;
        public decimal MaxKrediet
        {
            get
            {
                return maxKredietValue;
            }
            set
            {
                if (value > 0)
                    throw new KredietWaardeException("Krediet moet worden ingegeven als negatief getal", value);
                maxKredietValue = value;
            }
        }
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Maximum krediet: {0}", MaxKrediet);
        }
    }
}

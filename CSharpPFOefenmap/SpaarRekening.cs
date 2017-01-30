using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class SpaarRekening : Rekening
    {
        
        public SpaarRekening(string nummer, Klant eigenaar, decimal saldo)
            : base(nummer, eigenaar, saldo)
        {
        }
        private static float interestValue = 0.05f;

        public class InterestValueException : Exception
        {
            public InterestValueException(string message, float fouteValue)
                : base(message)
            {
                FouteInterst = fouteValue;
            }
            private float fouteInterestValue;
            public float FouteInterst
            {
                get
                {
                    return fouteInterestValue;
                }
                set
                {
                    fouteInterestValue = value;
                }
            }

        }

        public static float Interest
        {
            get
            {
                return SpaarRekening.interestValue;
            }

            set
            {
                if (value < 0)
                    throw new InterestValueException("De interest kan niet negatief zijn!", value);                
                SpaarRekening.interestValue = value;
            } 
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine($"Interest op de rekening: { Interest * 100}%");
        }
    }
}

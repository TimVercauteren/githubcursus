using System;

namespace Program
{
    public class KostPrijsException : Exception
    {
        public KostPrijsException(string message, decimal verkeerdePrijs)
            : base(message)
        {
            VerkeerdeKostprijs = verkeerdePrijs;
        }

        private decimal verkeerdeKostprijsValue;
        public decimal VerkeerdeKostprijs
        {
            get
            {
                return verkeerdeKostprijsValue;
            }
            set
            {
                verkeerdeKostprijsValue = value;
            }
        }

    }
}
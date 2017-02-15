using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBonMVVM.Model
{
    public class Parkeerbeurt
    {
        public Parkeerbeurt()
        {
            Datum = DateTime.Now;
            Aankomsttijd = DateTime.Now;
            Vertrektijd = Aankomsttijd;
            Bedrag = 0;
        }

        public DateTime Datum { get; set; }
        public DateTime Aankomsttijd { get; set; }
        public DateTime Vertrektijd { get; set; }
        public decimal Bedrag { get; set; }
    }
}

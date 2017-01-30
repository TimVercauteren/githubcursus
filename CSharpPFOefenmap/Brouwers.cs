using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Brouwers
    {
        public List<Brouwer> GetBrouwers()
        {
            Brouwer palm = new Brouwer { BrouwerNr = 1, BrouwerNaam = "Palm", isBelgisch = true };
            palm.Bieren = new List<Bier>
            {
                new Bier { BierNr=1, Biernaam="Palm Dobbel", Alcohol = 6.2F, Brouwer=palm },
                new Bier { BierNr=2, Biernaam="Palm Green", Alcohol = 0.1F, Brouwer=palm },
                new Bier { BierNr=3, Biernaam="Palm Royale", Alcohol=7.5F, Brouwer=palm }
            };

            Brouwer hertogJan = new Brouwer { BrouwerNr = 2, BrouwerNaam = "Hertog Jan", isBelgisch = false };
            hertogJan.Bieren = new List<Bier>
            {
                new Bier { BierNr=4, Biernaam="Hertog Jan Dubbel", Alcohol = 7F, Brouwer=hertogJan},
                new Bier { BierNr=5, Biernaam="Hertog JAn Grand Prestige", Alcohol=10.0f, Brouwer=hertogJan}
            };

            Brouwer inBev = new Brouwer { BrouwerNr = 3, BrouwerNaam = "InBev", isBelgisch = true };
            inBev.Bieren = new List<Bier>
            {
                new Bier { BierNr = 6, Biernaam="Belle-vue kriek L.A", Alcohol=1.2F, Brouwer=inBev },
                new Bier { BierNr = 7, Biernaam="Belle-vue kriek", Alcohol=5.2F,Brouwer=inBev },
                new Bier { BierNr = 8, Biernaam="Leffe Radieuse", Alcohol=8.2F, Brouwer=inBev },
                new Bier { BierNr = 9, Biernaam="Leffe Triple", Alcohol=8.5F, Brouwer=inBev }
            };

            return new List<Brouwer> { palm, hertogJan, inBev };
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Verwisselaar
    {
        public void Verwissel (int getal1, int getal2, out int verwisseld1, out int verwisseld2)
        {
            verwisseld1 = getal2;
            verwisseld2 = getal1;
        }
    }
}

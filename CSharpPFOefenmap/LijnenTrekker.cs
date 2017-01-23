using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class LijnenTrekker
    {
        public static void TrekLijn(int lengte, char symbool = '-')
        {
            for (int i = 0; i < lengte; i++)
            {
                Console.Write(symbool);
            }
            Console.WriteLine();
        }
        public static void TrekLijn()
        {
            TrekLijn(79);
        }
    }
}

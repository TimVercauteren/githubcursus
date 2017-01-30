using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
    public class LijnenTrekker
    {
        public static void TrekLijn(int x)
        {
            TrekLijn(x, '-');
        }
        
        public static void TrekLijn(int x, char y)
        {
            for (int i = 0; i < x; i++)
            {
                Console.Write(y);
            }
            Console.WriteLine();
        }
        public static void TrekLijn()
        {
            TrekLijn(45, '-');
        }
        public static void TrekLijn(char y)
        {
            TrekLijn(45, y);
        }
    }
}

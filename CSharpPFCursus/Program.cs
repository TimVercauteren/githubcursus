using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class Program
    {
        static readonly double guldenSnele = (Math.Sqrt(5.0) + 1.0) / 2.0;
        const decimal EuroKoers = 40.3399m;
        static void Main(string[] args)
        {
            DateTime tijd = new DateTime(1990,11,30);
            string [] nieuweTijd = tijd.GetDateTimeFormats();
            foreach (string s in nieuweTijd)
            {
                Console.WriteLine(s);
            }
        }
    }
}

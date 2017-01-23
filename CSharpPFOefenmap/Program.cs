using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma;
using Firma.Materiaal;
using Firma.Personeel;
using System.Collections;

namespace CSharpPFOefenmap
{
    class Program
    {
        static void Main(string[] args)
        {
            var land = "belgie";
            Console.WriteLine(land.ToUpperFirst());
            Console.WriteLine(land.Right(3));
        }
    }
}
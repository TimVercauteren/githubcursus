using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma;
using Firma.Materiaal;
using Firma.Personeel;
using System.Collections;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CSharpPFOefenmap
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var bestand = File.Open(@"C:\Data\Pizza.obj", FileMode.Open, FileAccess.Read))
                {
                    var lezer = new BinaryFormatter();
                    Pizza pizza;
                    pizza = (Pizza)lezer.Deserialize(bestand);
                    Console.WriteLine(pizza.Naam);
                    foreach (var onderdeel in pizza.Onderdelen)
                        Console.WriteLine(onderdeel);
                    Console.WriteLine(pizza.Prijs);
                }
            }
            catch (SerializationException)
            {
                Console.WriteLine("Fout bij het deserialiseren");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


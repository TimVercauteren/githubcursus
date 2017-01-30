using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Boek.Eigenaar = new Persoon("Peter", "Peeters");
                List<IVoorwerpen> voorwerpenLijst = new List<IVoorwerpen>
            {
                new LeesBoek("De zaak Alzheimer", new Persoon("Jef", "Geeraerts"),
                    25m, new Genre("Thriller", new Genre.DoelGroep(18)),
                    "Het verhaal van een huurmoordenaar met Alzheimer"),
                new WoordenBoek("Nederlands-Frans", new Persoon("Lowie","Van Daele"),
                    12m, new Genre("Educatief", new Genre.DoelGroep(18)), "Frans"),
                new BoekenRek(180, 60, 150m)
            };

                foreach (IVoorwerpen boekvoorwerp in voorwerpenLijst)
                    boekvoorwerp.GegevensTonen();

                var winsten =
                    from boek in voorwerpenLijst
                    select boek.Winst;
                Console.WriteLine($"Totale Winst: {winsten.Sum()} EUR");
                Console.WriteLine();
            }
            catch (BoekenRek.AfmetingException ex)
            {
                Console.WriteLine("FOUT:" + ex.Message + ": " + ex.VerkeerdeAfmeting);
            }
            catch (KostPrijsException ex)
            {
                Console.WriteLine("FOUT:" + ex.Message + ": " + ex.VerkeerdeKostprijs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("FOUT:" + ex.Message);
            }
            Console.WriteLine("Einde Programma..");

        }
    }
}

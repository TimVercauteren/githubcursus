using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Twitter
{
    class Program
    {
        static void Main(string[] args)
        {
            string welkomstBericht = "Wekom bij Twitter";
            Console.WriteLine(welkomstBericht);
            LijnenTrekker.TrekLijn(welkomstBericht.Length);
            int keuze = GeefKeuzeMenu();
            while (keuze != 4)
            {
                Console.WriteLine();
                try
                {
                    switch (keuze)
                    {
                        case 1:
                            Console.WriteLine("Tweet maken:");
                            Console.Write("Gebruikersnaam ?");
                            var gebruikersnaam = Console.ReadLine();
                            Console.WriteLine("Typ je tweet, max 140 chars!");
                            var bericht = Console.ReadLine();
                            Twitter.addTweet(new Tweet(gebruikersnaam, bericht, DateTime.Now));
                            break;
                        case 2:
                            var alleTweets = Twitter.AlleTweets();
                            Console.WriteLine("Alle tweets:\n");
                            foreach (Tweet t in alleTweets)
                            {
                                Console.WriteLine(t.ToString());
                            }
                            break;
                        case 3:
                            Console.Write("Wiens tweets wil je bekijken?");
                            var naam = Console.ReadLine();
                            var naamTweets = Twitter.AlleTweetsVan(naam);

                            if (naamTweets.Count() != 0)
                            {
                                Console.WriteLine("Tweets van {0}", naam);
                                foreach (Tweet t in naamTweets)
                                {
                                    Console.WriteLine(t.ToString());
                                }
                            }
                            else Console.WriteLine("Er zijn geen berichten van die persoon gevonden");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
                keuze = GeefKeuzeMenu();
            }
            Console.WriteLine("Einde van het programma, druk op <Enter> om te beëindigen");
        }
        static int GeefKeuzeMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Maak uw keuze <1>, <2> of <3>. Om te stoppen, geef <4>");
            LijnenTrekker.TrekLijn(54);
            Console.WriteLine("1. Twitterbericht plaatsen");
            Console.WriteLine("2. Alle tweets lezen");
            Console.WriteLine("3. Alle tweets lezen van een gebruiker");
            Console.WriteLine("4. Stop het programma");
            int keuze;
            while (int.TryParse(Console.ReadLine(), out keuze) && ((keuze < 0) || (keuze > 4)))
            {
                Console.WriteLine("Verkeerde keuze, geef een getal tussen 1 en 4 in");
            }
            return keuze;
        }
    }
}
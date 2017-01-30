using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Twitter
{
    public class Twitter
    {
        private static string TwitterPath = @"C:\Data\twitter.obj";

        public static void addTweets(Tweets tweets)
        {
            try
            {
                using (var bestand = File.Open(TwitterPath, FileMode.OpenOrCreate))
                {
                    var schrijver = new BinaryFormatter();
                    schrijver.Serialize(bestand, tweets);
                }
            }
            catch (SerializationException)
            {
                Console.WriteLine("Er is iets foutgelopen met het wegschrijven van de tweets");
            }
        }

        public static Tweets getTweets()
        {
            Tweets lijstTweets;
            try
            {
                using (var bestand = File.Open(TwitterPath, FileMode.Open, FileAccess.Read))
                {
                    var reader = new BinaryFormatter();
                    lijstTweets = (Tweets)reader.Deserialize(bestand);
                }
                return lijstTweets;
            }
            catch (SerializationException)
            {
                Console.WriteLine("Er is iets fout gegaan met het ophalen van de tweets");
            }
            return null;
        }

        public static List<Tweet> AlleTweets()
        {
            if (File.Exists(TwitterPath))
            {
                var tweets = getTweets();
                return tweets.AlleTweets().OrderByDescending(t => t.Tijdstip).ToList();
            }
            else
            {
                throw new Exception("Er is geen bestand met tweets!");
            }
        }

        public static List<Tweet> AlleTweetsVan(string naam)
        {
            return AlleTweets().Where(t => t.Naam.ToUpper() == naam.ToUpper()).ToList();
        }

        public static void clearTweets()
        {
            if (File.Exists(TwitterPath))
                File.Delete(TwitterPath);
        }

        public static void addTweet (Tweet tweet)
        {
            Tweets tweets;
            if (File.Exists(TwitterPath))
            {
                tweets = getTweets();
            }
            else
            {
                tweets = new Tweets();  //!! GEEN NULL REF ZETTEN -> NIEUWE AANMAKEN             
            }
            tweets.AddTweet(tweet);
            addTweets(tweets);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
    [Serializable]
    public  class Tweet
    {
        public Tweet(string naam, string bericht, DateTime tijd)
        {
            Naam = naam;
            Bericht = bericht;
            Tijdstip = tijd;
        }
        public string Naam { get; set; }

        private string berichtValue;
        public string Bericht
        {
            get
            {
                return berichtValue;
            }
            set
            {
                if (value.Length > 140)
                    throw new TweetTooLongException("Tweet is te lang! (max 140 tekens)", value);
                berichtValue = value;
            }
        }

        public DateTime Tijdstip { get; set; }

        public override string ToString()
        {
            string tijdstip = GetTijdstip();
            return (Naam + "\t- " + tijdstip + "\n" + Bericht + "\n");
        }
        private string GetTijdstip()
        {
            DateTime nu = DateTime.Now;
            TimeSpan test = nu - Tijdstip;
            int aantalDagenVerschil = test.Days;
            int aantalUrenVerschil = test.Hours;
            int aantalMinutenVerschil = test.Minutes;
            if (aantalDagenVerschil >= 1)
                return Tijdstip.Date.ToShortDateString();
            if (aantalUrenVerschil >= 1 )
                return ($"{aantalUrenVerschil} uur geleden");
            if (aantalMinutenVerschil >= 1)
                return ($"{aantalMinutenVerschil} minuten geleden");
            else
                return (String.Format("{0}:{1}" , Tijdstip.TimeOfDay.Hours,Tijdstip.TimeOfDay.Minutes));
        }
    }
    public class TweetTooLongException : Exception
    {
        public TweetTooLongException(string message, string bericht) : base(message)
        {
            this.FoutBericht = bericht;
        }
        public string FoutBericht { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTDD
{
    public class Persoon
    {
        private List<string> voornamen;

        public Persoon(List<string> voornamen)
        {
            if (!voornamen.Any())
            {
                throw new ArgumentException();
            }
            if (voornamen == null)
            {
                throw new ArgumentNullException();
            }
            foreach (string s in voornamen)
            {
                if (s == string.Empty)
                {
                    throw new ArgumentException();
                }
                if (s == null)
                {
                    throw new ArgumentNullException();
                }
                for (int i = 0; i < voornamen.IndexOf(s); i++)
                {
                    if (s.ToLower() == voornamen[i].ToLower())
                    {
                        throw new ArgumentException();
                    }
                }
                if (!s.All(k => char.IsLetter(k)))
                {
                    throw new ArgumentException();
                }
            }
            this.voornamen = voornamen;
        }
        public override string ToString()
        {
            StringBuilder namen = new StringBuilder();
            if (voornamen.Count > 1)
            {
                for (int i = 0; i < voornamen.Count - 1; i++)
                {
                    namen.Append(voornamen[i] + ' ');
                }
            }
            namen.Append(voornamen.Last());
            return namen.ToString();
        }
    }
}

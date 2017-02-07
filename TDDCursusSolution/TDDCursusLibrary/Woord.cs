using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCursusLibrary
{
    public class Woord
    {
        private readonly string woord;

        public Woord (string woord)
        {
            this.woord = woord;
        }
        public bool isPalinDroom()
        {
            var omgekeerd = new string(woord.ToArray().Reverse().ToArray());
            if ( omgekeerd == woord)
            {
                return true;
            }
            else
                return false;
        }
    }
}

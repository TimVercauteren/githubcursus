using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCursusLibrary
{
    public class ISBN
    {
        private const long GrootsteGetalmet13_Cijfers = 9999999999999L;
        private const long KleinsteGetalmet13_Cijfers = 1000000000000L;
        private long nummer;
        public ISBN(long nummer)
        {
            if (nummer < KleinsteGetalmet13_Cijfers || nummer > GrootsteGetalmet13_Cijfers)
                throw new ArgumentException();
            var somEven = 0L;
            var somOneven = 0L;
            var teVerwerkenCijfers = nummer / 10;
            for (int i = 0; i != 6; i++)
            {
                somEven += teVerwerkenCijfers % 10;
                teVerwerkenCijfers /= 10;
                somOneven += teVerwerkenCijfers % 10;
                teVerwerkenCijfers /= 10;
            }
            var controleGetal = (3 * somEven) + somOneven;
            var dichsteTiental = controleGetal - controleGetal % 10 + 10;
            var verschil = dichsteTiental - controleGetal;
            var laatsteGetal = nummer % 10;
            if (verschil == 10)
            {
                if ((laatsteGetal) != 0)
                    throw new ArgumentException();
            }
            else
            {
                if (laatsteGetal != verschil)
                    throw new ArgumentException();
            }
            this.nummer = nummer;

        }


        public override string ToString()
        {
            return nummer.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Breuk
    {
        public Breuk (int teller, int noemer)
        {
            Teller = teller;
            Noemer = noemer;
        }

        private int tellerValue;
        private int noemerValue;
        public int Teller
        {
            get
            {
                return tellerValue;
            }
            set
            {
                tellerValue = value;
            }
        }
        public int Noemer
        {
            get
            {
                return noemerValue;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Noemer mag niet nul zijn");
                }
                noemerValue = value;
            }
        }
        public override string ToString()
        {
            return Teller + "/" + Noemer;
        }
        public override bool Equals(object obj)
        {
            if (obj is Breuk)
            {
                Breuk andereBreuk = (Breuk)obj;
                return ((decimal)Teller / Noemer == (decimal)andereBreuk.Teller / andereBreuk.Noemer);
            }
            else return false;
        }
        public override int GetHashCode()
        {
            return Teller + Noemer;
        }
        public static bool operator ==(Breuk eerste, Breuk tweede)
        {
            return eerste.Equals(tweede);
        }
        public static bool operator !=(Breuk eerste, Breuk tweede)
        {
            return !eerste.Equals(tweede);
        }
        public static Breuk operator *(Breuk eerste, Breuk tweede)
        {
            return new Breuk(eerste.Teller * tweede.Teller, eerste.Noemer * tweede.Noemer);
        }
        public static Breuk operator *(Breuk eerste, int waarde)
        {
            return new Breuk(eerste.Teller * waarde, eerste.Noemer);
        }
        public static Breuk operator ++(Breuk breuk)
        {
            return new Breuk(breuk.Teller + breuk.Noemer, breuk.Noemer);
        }
        public static implicit operator double(Breuk breuk)
        {
            return (double)breuk.Teller / (double)breuk.Noemer;
        }
        public static explicit operator int (Breuk breuk)
        {
            return breuk.Teller / breuk.Noemer;
        }
        public static bool operator true(Breuk breuk)
        {
            return breuk.Teller < breuk.Noemer;
        }
        public static bool operator false(Breuk breuk)
        {
            return !breuk;
        }
        public static bool operator !(Breuk breuk)
        {
            if (breuk)
                return false;
            else
                return true;
        }
    }
}

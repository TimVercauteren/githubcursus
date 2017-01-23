using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Omzetter
    {
        public const double CentimersPerInch = 2.54d;
        public double CmNaarInch (double cm)
        {
            return cm / CentimersPerInch;
        }
        public double InchNaarCm(double inch)
        {
            return inch * CentimersPerInch;
        }
    }
}

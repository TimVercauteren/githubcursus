using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class StookKetel : IVervuiler
    {
        public StookKetel(float coNorm)
        {
            this.CONorm = coNorm;
        }
        private float coNormValue;
        public float CONorm
        {
            get
            {
                return coNormValue;
            }
            set
            {
                if (value > 0)
                coNormValue = value;
            }
        }

        public double GeefVervuiling()
        {
            return CONorm * 100;
        }
    }
}

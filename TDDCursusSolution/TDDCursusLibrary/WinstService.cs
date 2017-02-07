using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCursusLibrary
{
    public class WinstService
    {
        public WinstService (IOpbrengstDAO opbrengstDAO, IKostDAO totalekostDAO)
        {
            opbrengstValue = opbrengstDAO.TotaleOpbrengst();
            totaleKostValue = totalekostDAO.TotaleKost();
        }
        private decimal opbrengstValue;
        private decimal totaleKostValue;
        public decimal Winst
        {
            get
            {
                return opbrengstValue-totaleKostValue;
            }
        }
    }
}

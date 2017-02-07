using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    class KostDAOStub : IKostDAO
    {
        public decimal TotaleKost()
        {
            return 600;
        }
    }
}

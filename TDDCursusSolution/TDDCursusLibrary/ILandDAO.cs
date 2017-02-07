using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCursusLibrary
{
    public interface ILandDAO
    {
        Land Read(string landcode);
        int OppervlakteAlleLanden();
    }
}

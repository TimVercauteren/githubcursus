using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpPFOefenmap
{
    class ProvincieInfo
    {
        public int ProvincieGrootte(string provincieNaam)
        {
            using (StreamReader lezer = new StreamReader(@"C:\Users\tim.vercauteren\Documents\provincies.txt"))
            {

                string regel;
                while ((regel = lezer.ReadLine()) != null)
                {
                    int dubbelPuntpos = regel.IndexOf(':');
                    string provincie = regel.Substring(0, dubbelPuntpos);
                    if (provincie == provincieNaam)
                        return int.Parse(regel.Substring(dubbelPuntpos + 1));
                }
            }

            throw new Exception("Onbestaande provincie:" + provincieNaam);

        }
    }
}

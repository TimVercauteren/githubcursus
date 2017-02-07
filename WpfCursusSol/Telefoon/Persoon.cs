using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Telefoon
{
    public class Persoon
    {
        public Persoon(string naam, string telefoonnr, DoelGroep groep,
            BitmapImage foto)
        {
            Naam = naam;
            Telefoonnr = telefoonnr;
            Groep = groep;
            Foto = foto;
        }
        public string Naam { get; set; }
        public string Telefoonnr { get; set; }
        public BitmapImage Foto { get; set; }
        public DoelGroep Groep { get; set; }
        public enum DoelGroep
        {
            Familie,
            Vrienden,
            Werk
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HobbyLijst
{
    public class Hobby
    {
        public string Categorie { get; set; }
        public string Activiteit { get; set; }
        public BitmapImage Symbool { get; set; }
        public Hobby(string _Categorie, string _Activiteit, BitmapImage _Symbool)
        {
            Categorie = _Categorie;
            Activiteit = _Activiteit;
            Symbool = _Symbool;
        }


    }
}

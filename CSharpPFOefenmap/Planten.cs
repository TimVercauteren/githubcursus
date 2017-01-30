using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Planten
    {
        public List<Plant> GetPlanten()
        {
            var plantenTabel = new List<Plant>
            {
                new Plant ( 1, "Tulp", "Rood", 0.5m, "Bol" ),
                new Plant ( 2, "Krokus", "Wit", 0.2m, "Bol"),
                new Plant(3, "Narcis", "Geel", 0.3m, "Bol"),
                new Plant(4, "Blauw druifje", "Blauw", 0.2m, "Bol"),
                new Plant(5, "Azalea", "Rood", 3.00m, "Heester"),
                new Plant(6, "Forsythia", "Geel", 2.00m, "Heester"),
                new Plant(7, "Magnolia", "Wit", 4.00m, "Heester"),
                new Plant(8, "Waterlelie", "Wit", 2.0m, "Water"),
                new Plant(9, "Lisdodde", "Geel", 3.0m, "Water"),
                new Plant(10, "Kalmoes", "Geel", 3.00m, "Water"),
                new Plant(11, "Bieslook", "Paars", 1.50m, "Kruid"),
                new Plant(12, "Rozemarijn", "Blauw", 1.25m, "Kruid"),
                new Plant(13, "Munt", "Wit", 1.10m, "Kruid"),
                new Plant(14, "Dragon", "Wit", 1.30m, "Kruid"),
                new Plant(15, "Basilicum", "Wit", 1.50m, "Kruid")
            };
            return plantenTabel;
        }
    }
}

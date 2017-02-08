using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace BloemSamenstelling
{
    /// <summary>
    /// Interaction logic for BloemWindow.xaml
    /// </summary>
    public partial class BloemWindow : Window
    {
         public BloemWindow()
        {
            InitializeComponent();
            foreach (PropertyInfo info in typeof(Colors).GetProperties())
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush kleurke =
                    (SolidColorBrush)bc.ConvertFromString(info.Name);
                Kleur kleur = new Kleur();
                kleur.Borstel = kleurke;
                kleur.Naam = info.Name;
                kleur.Hex = kleurke.ToString();
                kleur.Rood = kleurke.Color.R;
                kleur.Groen = kleurke.Color.G;
                kleur.Blauw = kleurke.Color.B;
                foreach (object o in kleurPaneel.Children)
                {
                    if (o is ComboBox)
                    {
                        ComboBox c =(ComboBox) o;
                        c.Items.Add(kleur);
                        if (kleur.Naam == "Black")
                        {
                            c.SelectedItem = kleur;
                        }
                    }
                }
            }
        }
    }
}

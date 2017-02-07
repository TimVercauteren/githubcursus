using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace Pizza
{
    /// <summary>
    /// Interaction logic for PizzaWindow.xaml
    /// </summary>
    public partial class PizzaWindow : Window
    {
        public PizzaWindow()
        {
            InitializeComponent();
        }
        private void plusHoeveelheid_Click(object sender, RoutedEventArgs e)
        {
            int hoeveelheid;
            if ((hoeveelheid = Convert.ToInt16(tarHoeveelheid.Content)) < 10)
                hoeveelheid++;
            tarHoeveelheid.Content = hoeveelheid.ToString();
        }

        private void minHoeveelheid_Click(object sender, RoutedEventArgs e)
        {
            int hoeveelheid;
            if ((hoeveelheid = Convert.ToInt16(tarHoeveelheid.Content)) > 1)
                hoeveelheid--;
            tarHoeveelheid.Content = hoeveelheid.ToString();
        }

        private void BestelKnop_Click(object sender, RoutedEventArgs e)
        {
           
            string opties = string.Empty;
            string extras = string.Empty;
            string grootte = "large";
            foreach (FrameworkElement kind in optiesPaneel.Children)
            {
                if (kind is CheckBox)
                {
                    var kindC = (CheckBox)kind;
                    if (kindC.IsChecked == true)
                    {
                        opties += kindC.Content + " ";
                    }
                }
            }
            foreach (FrameworkElement kind in extraOpties.Children)
            {
                if (kind is ToggleButton)
                {
                    var kindC = (ToggleButton)kind;
                    if (kindC.IsChecked == true)
                    {
                        if (extras == string.Empty)
                        {
                            extras += kindC.Tag;
                        }
                        else
                            extras += " en " +kindC.Tag;
                    }
                }
            }
            foreach(FrameworkElement kind in Grootte.Children)
            {
                var kindC = (RadioButton)kind;
                if (kindC.IsChecked == true)
                {
                    grootte = kindC.Content.ToString();
                }
            }
            Bestelling.Content = string.Format("U heeft {0} {1} pizza('s) besteld met: {2} \nExtra opties: {3}",
                tarHoeveelheid.Content, grootte, opties, extras);

        }
    }
}

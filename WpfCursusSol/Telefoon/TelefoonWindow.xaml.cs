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
using System.ComponentModel;
using System.Media;

namespace Telefoon
{
    /// <summary>
    /// Interaction logic for TelefoonWindow.xaml
    /// </summary>
    public partial class TelefoonWindow : Window
    {
        public TelefoonWindow()
        {
            InitializeComponent();
        }
        public List<Persoon> personen = new List<Persoon>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            personen.Add(new Persoon("Anne", "0498 83 65 12", Persoon.DoelGroep.Vrienden,
                new BitmapImage(new Uri(@"Images\anne.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Bob", "0498 65 23 14", Persoon.DoelGroep.Vrienden,
                new BitmapImage(new Uri(@"Images\bob.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Tom", "0478 85 34 16", Persoon.DoelGroep.Werk,
                new BitmapImage(new Uri(@"Images\collega1.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Steven", "0483 15 32 47", Persoon.DoelGroep.Werk,
                new BitmapImage(new Uri(@"Images\collega2.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Yves", "0470 12 79 08", Persoon.DoelGroep.Werk,
                new BitmapImage(new Uri(@"Images\collega3.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Ed", "0499 99 99 99", Persoon.DoelGroep.Vrienden,
                new BitmapImage(new Uri(@"Images\ed.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Astrid", "0498 45 13 18", Persoon.DoelGroep.Familie,
                new BitmapImage(new Uri(@"Images\grotezus.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Jannick", "0498 17 15 67", Persoon.DoelGroep.Familie,
                new BitmapImage(new Uri(@"Images\kleinezus.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Inge", "0498 40 32 28", Persoon.DoelGroep.Familie,
                new BitmapImage(new Uri(@"Images\tantenon.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Pa", "0498 75 83 54", Persoon.DoelGroep.Familie,
                new BitmapImage(new Uri(@"Images\vader.jpg", UriKind.Relative))));

            categorieKeuze.Items.Add("Iedereen");
            categorieKeuze.Items.Add("Familie");
            categorieKeuze.Items.Add("Vrienden");
            categorieKeuze.Items.Add("Werk");
            categorieKeuze.SelectedIndex = 0;
        }

        private void categorieKeuze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nummerKeuze.Items.Clear();
            foreach (Persoon p in personen)
            {
                if ( p.Groep.ToString() == categorieKeuze.SelectedItem.ToString() ||
                    categorieKeuze.SelectedIndex == 0) //Het 'OR' statement zorgt ervoor dat er altijd een default is
                {
                    nummerKeuze.Items.Add(p);
                }
            }
            nummerKeuze.Items.SortDescriptions.Add(
                new SortDescription("Naam", ListSortDirection.Ascending));
        }

        private void TelefoonButton_Click(object sender, RoutedEventArgs e)
        {
            Persoon p = (Persoon)nummerKeuze.SelectedItem;
            if (nummerKeuze.SelectedIndex == -1)
            {
                MessageBox.Show("Je moet eerst iemand aanduiden!", "Niemand aangeduid",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
               if(MessageBox.Show($"Wil je {p.Naam} bellen?\nNummer: {p.Telefoonnr}", "Telefoon",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes)
                    == MessageBoxResult.Yes)
                {
                    SoundPlayer speler = new SoundPlayer(@"phone.wav");
                    speler.Play();
                }
            }
        }
    }
}

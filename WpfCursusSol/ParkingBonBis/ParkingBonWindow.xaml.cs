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
using Microsoft.Win32;
using System.IO;

namespace ParkingBon
{
    /// <summary>
    /// Interaction logic for ParkingBonWindow.xaml
    /// </summary>
    public partial class ParkingBonWindow : Window
    {
        public ParkingBonWindow()
        {
            InitializeComponent();
            Nieuw();
        }


        private void Nieuw()
        {
            DatumBon.SelectedDate = DateTime.Now;
            AankomstLabelTijd.Content = DateTime.Now.ToLongTimeString();
            TeBetalenLabel.Content = "0 €";
            VertrekLabelTijd.Content = AankomstLabelTijd.Content;
            StatusDir.Content = "Nieuwe bon";
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Programma afsluiten ?", "Afsluiten", MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            if (bedrag > 0)
                bedrag -= 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content =
                Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
            if (bedrag < 1)
            {
                minder.IsEnabled = false;
                OpslaanKnop.IsEnabled = false;
                AfdrukKnop.IsEnabled = false;
                SaveButton.IsEnabled = false;
                PrintButton.IsEnabled = false;
            }
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
                bedrag += 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content =
                Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
            if (bedrag > 0)
            {
                minder.IsEnabled = true;
                OpslaanKnop.IsEnabled = true;
                AfdrukKnop.IsEnabled = true;
                SaveButton.IsEnabled = true;
                PrintButton.IsEnabled = true;
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                DateTime aankomst = Convert.ToDateTime(AankomstLabelTijd.Content);
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = $"{aankomst.Day}-{aankomst.Month}-{aankomst.Year}" +
                    $"om{aankomst.Hour}-{aankomst.Minute}-{aankomst.Second}";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Parkeerbon |*.bon";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        DatumBon.DataContext = Convert.ToDateTime(bestand.ReadLine());
                        AankomstLabelTijd.Content = Convert.ToDateTime(bestand.ReadLine()).ToLongTimeString();
                        TeBetalenLabel.Content = bestand.ReadLine().ToString();
                        VertrekLabelTijd.Content = Convert.ToDateTime(bestand.ReadLine()).ToLongTimeString();
                    }
                    StatusDir.Content = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout tijdesn het openen: " + ex.Message);
            }
        }

        private void Niew(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                DateTime aankomst = Convert.ToDateTime(AankomstLabelTijd.Content);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = $"{aankomst.Day}-{aankomst.Month}-{aankomst.Year}" +
                    $"om{aankomst.Hour}-{aankomst.Minute}-{aankomst.Second}";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Parkeerbon |*.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(aankomst.ToShortDateString());
                        bestand.WriteLine(AankomstLabelTijd.Content.ToString());
                        bestand.WriteLine(TeBetalenLabel.Content.ToString());
                        bestand.WriteLine(VertrekLabelTijd.Content.ToString());
                    }
                    StatusDir.Content = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Opslaan mislukt: " + ex.Message);
            }
        }

        private void PrintPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}

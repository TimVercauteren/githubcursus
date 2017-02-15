using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace ParkingBonMVVM.ViewModel
{
    public class ParkeerbeurtVM : ViewModelBase
    {
        private Model.Parkeerbeurt parkeerbeurt;

        public ParkeerbeurtVM(Model.Parkeerbeurt parkeerbeurt)
        {
            this.parkeerbeurt = parkeerbeurt;
        }

        public DateTime Datum
        {
            get
            {
                return parkeerbeurt.Datum;
            }
            set
            {
                parkeerbeurt.Datum = value;
                RaisePropertyChanged("Datum");
            }
        }
    
        public DateTime AankomstTijd
        {
            get
            {
                return parkeerbeurt.Aankomsttijd;
            }
            set
            {
                parkeerbeurt.Aankomsttijd= value;
                RaisePropertyChanged("AankomstTijd");
            }
        }

        public DateTime VertrekTijd
        {
            get
            {
                return parkeerbeurt.Vertrektijd;
            }
            set
            {
                parkeerbeurt.Vertrektijd = value;
                RaisePropertyChanged("Vertrektijd");
            }
        }

        public decimal Bedrag
        {
            get
            {
                return parkeerbeurt.Bedrag;
            }
            set
            {
                parkeerbeurt.Bedrag = value;
                RaisePropertyChanged("Bedrag");
            }
        }

        public RelayCommand<RoutedEventArgs> PlusCommand
        {
            get { return new RelayCommand<RoutedEventArgs>(VerhoogBedrag); }
        }

        public RelayCommand<RoutedEventArgs> MinCommand
        {
            get { return new RelayCommand<RoutedEventArgs>(VerlaagBedrag); }
        }

        private void VerhoogBedrag(RoutedEventArgs e)
        {
            DateTime tienU = new DateTime(1, 1, 1, 22, 0, 0);
            if (VertrekTijd.TimeOfDay < tienU.TimeOfDay)
            {
                Bedrag += 0.5m;
                VertrekTijd = VertrekTijd.AddMinutes(30);
                if (VertrekTijd.TimeOfDay > tienU.TimeOfDay)
                {
                    VertrekTijd = VertrekTijd.Subtract(VertrekTijd.TimeOfDay - tienU.TimeOfDay);

                }
            }
        }
        private void VerlaagBedrag(RoutedEventArgs e)
        {
            if (Bedrag > 0)
            {
                VertrekTijd = VertrekTijd.Subtract(new TimeSpan(0, 30, 0));
                Bedrag -= 0.5m;
            }
            if (VertrekTijd < AankomstTijd)
            {
                VertrekTijd = AankomstTijd;
            }
        }

        public RelayCommand OpenCommand
        {
            get { return new RelayCommand(OpenBestand); }
        }

        private void OpenBestand()
        {
            throw new NotImplementedException();
        }

        public RelayCommand SaveCommand
        {
            get { return new RelayCommand(SaveBestand); }
        }

        private void SaveBestand()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "parkeerbon";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "parkeerbonnen |*.bon";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine($"Datum: {AankomstTijd.Date.ToShortDateString()}");
                        bestand.WriteLine("Aankomstuur: ");
                        bestand.WriteLine("Vertrekuur: ");
                        bestand.WriteLine("Betaald bedrag: ");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fout: " + ex.Message, "Fout!");
            }
        }

        public RelayCommand NewCommand
        {
            get { return new RelayCommand(NieuwBestand); }
        }

        private void NieuwBestand()
        {
            Bedrag = 0;
            AankomstTijd = DateTime.Now;
            VertrekTijd = DateTime.Now;
        }
    }
}

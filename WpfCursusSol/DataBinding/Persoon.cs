using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;

namespace DataBinding
{
    public class Persoon : INotifyPropertyChanged
    {
        public Persoon(string naam, decimal wedde, DateTime indienst)
        {
            Naam = naam;
            Wedde = wedde;
            InDienst = indienst;
        }

        private string naamValue;
        public string Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                naamValue = value;
                RaisePropertyChanged("Naam");
            }
        }
        private decimal weddeValue;

        public decimal Wedde
        {
            get { return weddeValue; }
            set
            {
                weddeValue = value;
                RaisePropertyChanged("Wedde");
            }
        }

        private DateTime inDienstValue;

        public DateTime InDienst
        {
            get { return inDienstValue; }
            set {
                inDienstValue = value;
                RaisePropertyChanged("Indienst");
            }
        }

        private void RaisePropertyChanged(string info)
        {
            if (PropertyChanged!= null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}

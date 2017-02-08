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
using System.ComponentModel;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataBindingWindow : Window
    {
        public Persoon persoon = new Persoon("Jan",1800m, DateTime.Today);
        public DataBindingWindow()
        {
            InitializeComponent();
            SortDescription sd = new SortDescription("Source", ListSortDirection.Ascending);
            lettertypeCombobox.Items.SortDescriptions.Add(sd);
            lettertypeCombobox.SelectedItem = new FontFamily("Arial");
            veranderPanel.DataContext = persoon;
        }

        private void toonNaamButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(persoon.Naam);
        }

        private void veranderButton_Click(object sender, RoutedEventArgs e)
        {
            persoon.Naam = "piet";
        }
    }
}

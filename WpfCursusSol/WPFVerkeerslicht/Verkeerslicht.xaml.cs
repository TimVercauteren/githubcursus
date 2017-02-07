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

namespace WPFVerkeerslicht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpgelet_Click(object sender, RoutedEventArgs e)
        {
            if (RoodLicht.Opacity == 1)
            {
                RoodLicht.Opacity = 0;
                ButtonGo.IsEnabled = true;
            }
            else
            {
                GroenLicht.Opacity = 0;
                goKnop.IsEnabled = true;
            }
            OranjeLicht.Opacity = 1;
            this.IsEnabled = false;
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            RoodLicht.Opacity = 1;
            OranjeLicht.Opacity = 0;
            this.IsEnabled = false;
            ButtonOpgelet.IsEnabled = true;
        }

        private void goKnop_Click(object sender, RoutedEventArgs e)
        {
            GroenLicht.Opacity = 1;
            OranjeLicht.Opacity = 0;
            this.IsEnabled = false;
            ButtonOpgelet.IsEnabled = true;
        }
    }
}

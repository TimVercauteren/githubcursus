using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMHobby
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModel.HobbyLijstVM vm = new ViewModel.HobbyLijstVM();
            View.HobbyLijstView hobbyview = new View.HobbyLijstView();
            hobbyview.DataContext = vm;
            hobbyview.Show();
        }
    }
}

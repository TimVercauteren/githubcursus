﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ParkingBonMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Model.Parkeerbeurt pb = new Model.Parkeerbeurt();
            ViewModel.ParkeerbeurtVM vm = new ViewModel.ParkeerbeurtVM(pb);
            View.ParkingBonView parkeerbonView = new View.ParkingBonView();
            parkeerbonView.DataContext = vm;
            parkeerbonView.Show();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WindowMetRibbonControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowMetRibbon
    {
        public WindowMetRibbon()
        {
            InitializeComponent();
            LeesMRU();
            if (Properties.Settings.Default.qat != null)
            {
                System.Collections.Specialized.StringCollection qatlijst =
                    Properties.Settings.Default.qat;
                int lijnnr = 0;
                while (lijnnr < qatlijst.Count)
                {
                    string commando = qatlijst[lijnnr];
                    string png = qatlijst[lijnnr + 1];
                    RibbonButton nieuweKnop = new RibbonButton();
                    BitmapImage icon = new BitmapImage();
                    icon.BeginInit();
                    icon.UriSource = new Uri(png);
                    icon.EndInit();
                    nieuweKnop.SmallImageSource = icon;

                    CommandBindingCollection ccol = this.CommandBindings;
                    foreach(CommandBinding cb in ccol)
                    {
                        RoutedUICommand rcb = (RoutedUICommand)cb.Command;
                        if (rcb.Text == commando)
                            nieuweKnop.Command = rcb;
                    }
                    Qat.Items.Add(nieuweKnop);
                    lijnnr += 2;
                }
            }
        }

        private void LeesMRU()
        {
            MRUGalleryCat.Items.Clear();
            if (Properties.Settings.Default.mru != null)
            {
                System.Collections.Specialized.StringCollection mrulijst =
                    Properties.Settings.Default.mru;
                for (int lijnnr = 0; lijnnr < mrulijst.Count; lijnnr++)
                {
                    MRUGalleryCat.Items.Add(mrulijst[lijnnr]);
                }
            }
        }

        private void BijwerkenMRU(string bestandsnaam)
        {
            System.Collections.Specialized.StringCollection mrulijst = new
                System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.mru != null)
            {
                mrulijst = Properties.Settings.Default.mru;
                int positie = mrulijst.IndexOf(bestandsnaam);
                if (positie >= 0)
                {
                    mrulijst.RemoveAt(positie);
                }
                else
                {
                    if (mrulijst.Count >= 6)
                        mrulijst.RemoveAt(5);
                }
                mrulijst.Insert(0, bestandsnaam);
                Properties.Settings.Default.mru = mrulijst;
                Properties.Settings.Default.Save();
                LeesMRU();
            }
        }

        private void LeesBestand(string bestandsnaam)
        {
            try
            {
                using (StreamReader bestand = new StreamReader(bestandsnaam))
                {
                    TextBoxVoorbeeld.Text = bestand.ReadLine();
                }
                BijwerkenMRU(bestandsnaam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".rvb";
            dlg.Filter = "Ribbon documents |*.rvb";

            if (dlg.ShowDialog() == true)
            {
                LeesBestand(dlg.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".rvb";
                dlg.Filter = "Ribbon documents |*.rvb";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(TextBoxVoorbeeld.Text);
                    }
                }
                BijwerkenMRU(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt : " + ex.Message);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            TextBoxVoorbeeld.Text = string.Empty;
        }

        private void PrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog afdrukken = new PrintDialog();
            if (afdrukken.ShowDialog() == true)
            {
                MessageBox.Show("Hier zou worden afgedrukt");
            }
        }

        private void PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Hier zou een afdrukvoorbeeld moeten verschijnen");
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Dit is helpscherm", "Help", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        private void MRUGallery_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LeesBestand(MRUGallery.SelectedValue.ToString());
        }

        private void Radio_Click(object sender, RoutedEventArgs e)
        {
            RibbonRadioButton Keuze = (RibbonRadioButton)sender;
            BrushConverter bc = new BrushConverter();
            SolidColorBrush kleur = (SolidColorBrush)bc.ConvertFromString(Keuze.Tag.ToString());
            TextBoxVoorbeeld.Foreground = kleur;
        }

        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Collections.Specialized.StringCollection qatlijst =
                new System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.qat != null)
                Properties.Settings.Default.qat.Clear();
            foreach (Object li in Qat.Items)
            {
                if (li is RibbonButton)
                {
                    RibbonButton knop = (RibbonButton)li;
                    RoutedUICommand commando = (RoutedUICommand)knop.Command;
                    qatlijst.Add(commando.Text);
                    qatlijst.Add(knop.SmallImageSource.ToString());
                }
            }
            if (qatlijst.Count > 0)
            {
                Properties.Settings.Default.qat = qatlijst;
            }
            Properties.Settings.Default.Save();
        }
    }
}


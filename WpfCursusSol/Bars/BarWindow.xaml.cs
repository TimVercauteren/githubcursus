﻿using System;
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
using Microsoft.Win32;
using System.IO;

namespace Bars
{
    /// <summary>
    /// Interaction logic for BarWindow.xaml
    /// </summary>
    public partial class BarWindow : Window
    {
        public BarWindow()
        {
            InitializeComponent();

            CommandBinding mijnCtrlB =
                new CommandBinding(mijnRouteCtrlB, ctrlBExecuted);
            this.CommandBindings.Add(mijnCtrlB);
            KeyGesture toetsCtrlB =
                new KeyGesture(Key.B, ModifierKeys.Control);
            KeyBinding mijnKeyCtrlB =
                new KeyBinding(mijnRouteCtrlB, toetsCtrlB);
            this.InputBindings.Add(mijnKeyCtrlB);

            CommandBinding mijnCtrlI =
                new CommandBinding(mijnRouteCtrlI, ctrlIExecuted);
            this.CommandBindings.Add(mijnCtrlI);
            KeyGesture toetsCtrlI =
                new KeyGesture(Key.I, ModifierKeys.Control);
            KeyBinding mijnKeyCtrlI =
                new KeyBinding(mijnRouteCtrlI, toetsCtrlI);
            this.InputBindings.Add(mijnKeyCtrlI);
        }

        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            LettertypeComboBox.Items.SortDescriptions.Add(
                new SortDescription("Source", ListSortDirection.Ascending));
            LettertypeComboBox.SelectedItem =
                new FontFamily(TextBoxVoorbeeld.FontFamily.ToString());
        }

        private void MenuVet_Click(object sender, RoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }
        private void Vet_Aan_Uit(bool wissel = false)
        {
            if ((wissel == true && TextBoxVoorbeeld.FontWeight == FontWeights.Bold) ||
                (wissel == false && TextBoxVoorbeeld.FontWeight == FontWeights.Normal))
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Bold;
                MenuVet.IsChecked = true;
                ButtonVet.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Normal;
                MenuVet.IsChecked = false;
                ButtonVet.IsChecked = false;
            }
        }

        private void Schuin_Aan_Uit(bool wissel = false)
        {
            if ((wissel == true && TextBoxVoorbeeld.FontStyle == FontStyles.Italic) || 
                (wissel == false && TextBoxVoorbeeld.FontStyle == FontStyles.Normal))
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Italic;
                MenuSchuin.IsChecked = true;
                ButtonSchuin.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Normal;
                MenuSchuin.IsChecked = false;
                ButtonSchuin.IsChecked = false;
            }
        }

        private void MenuSchuin_Click(object sender, RoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }

        private void Lettertype_Click(object sender, RoutedEventArgs e)
        {
            MenuItem hetlettertype = (MenuItem)sender;
            foreach (MenuItem huiding in Fontjes.Items)
            {
                huiding.IsChecked = false;
            }
            hetlettertype.IsChecked = true;
            LettertypeComboBox.SelectedItem = new FontFamily(hetlettertype.Header.ToString());
        }

        public static RoutedCommand mijnRouteCtrlB = new RoutedCommand();
        public static RoutedCommand mijnRouteCtrlI = new RoutedCommand();

        private void ctrlBExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }
        private void ctrlIExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }

        private void LettertypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (MenuItem huidig in Fontjes.Items)
            {
                if (LettertypeComboBox.SelectedItem.ToString() ==
                    huidig.Header.ToString())
                {
                    huidig.IsChecked = true;
                }
                else
                    huidig.IsChecked = false;
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents |*.txt";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(LettertypeComboBox.SelectedValue);
                        bestand.WriteLine(TextBoxVoorbeeld.FontWeight.ToString());
                        bestand.WriteLine(TextBoxVoorbeeld.FontStyle.ToString());
                        bestand.WriteLine(TextBoxVoorbeeld.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt: " + ex.Message);
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents |*.txt";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        LettertypeComboBox.SelectedValue =
                            new FontFamily(bestand.ReadLine());
                        TypeConverter converBold =
                            TypeDescriptor.GetConverter(typeof(FontWeight));
                        TextBoxVoorbeeld.FontWeight =
                            (FontWeight)converBold.ConvertFromString(bestand.ReadLine());
                        Vet_Aan_Uit(true);
                        TypeConverter convertStyle =
                            TypeDescriptor.GetConverter(typeof(FontStyle));
                        TextBoxVoorbeeld.FontStyle =
                            (FontStyle)convertStyle.ConvertFromString(bestand.ReadLine());
                        Schuin_Aan_Uit(true);

                        TextBoxVoorbeeld.Text = bestand.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt: " + ex.Message);
            }
        }

        private double A4Breedte = 21 / 2.54 * 96;
        private double A4Hoogte = 29.7 / 2.54 * 96;
        private double vertPositie;

        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new System.Windows.Size(A4Breedte, A4Hoogte);

            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);

            FixedPage page = new FixedPage();
            inhoud.Child = page;
            page.Width = A4Breedte;
            page.Height = A4Hoogte;
            vertPositie = 96;

            page.Children.Add(Regel("gebruikt lettertype: " +
                TextBoxVoorbeeld.FontFamily.ToString()));
            page.Children.Add(Regel("gewicht van het lettertype: " +
                TextBoxVoorbeeld.FontWeight.ToString()));
            page.Children.Add(Regel("stijl van het lettertype: " +
                TextBoxVoorbeeld.FontStyle.ToString()));
            page.Children.Add(Regel(""));
            page.Children.Add(Regel("inhoud van de tekstbox: "));
            for (int i = 0; i < TextBoxVoorbeeld.LineCount; i++)
            {
                page.Children.Add(Regel(TextBoxVoorbeeld.GetLineText(i)));
            }
            return document;

        }

        private TextBlock Regel(string v)
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Text = v;
            deRegel.FontSize = TextBoxVoorbeeld.FontSize;
            deRegel.FontStyle = TextBoxVoorbeeld.FontStyle;
            deRegel.FontFamily = TextBoxVoorbeeld.FontFamily;
            deRegel.FontWeight = TextBoxVoorbeeld.FontWeight;
            deRegel.Margin = new Thickness(96, vertPositie, 96, 96);
            vertPositie += 30;
            return deRegel;
        }

        private void PrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog afdrukken = new PrintDialog();
            if (afdrukken.ShowDialog() == true)
            {
                afdrukken.PrintDocument(StelAfdrukSamen().DocumentPaginator, "tekstbox");
            }
        }

        private void PriviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Afdrukvoorbeeld preview = new Afdrukvoorbeeld();
            preview.Owner = this;
            preview.AfdrukDocument = StelAfdrukSamen();
            preview.ShowDialog();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Programma afsluiten ?",
                                    "Afsluiten",
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Question,
                                    MessageBoxResult.No) == MessageBoxResult.No)
                e.Cancel = true;
        }


        private void Closing_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}

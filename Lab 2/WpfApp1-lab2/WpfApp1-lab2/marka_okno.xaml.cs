using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1_lab2
{
    /// <summary>
    /// Logika interakcji dla klasy marka_okno.xaml
    /// </summary>
    
    public partial class marka_okno : Window
    {
        public int ile = 0;
        public int poliska = 0;

        public marka_okno(int suma_cen)
        {
            InitializeComponent();
            this.ile = suma_cen;
            cena_marka.Content = ile + poliska;

        }

       

        private void fiat_Checked(object sender, RoutedEventArgs e)
        {
            if (fiat.IsChecked == true)
                ile = ile + 1000;
            else
                ile = ile - 1000;
            cena_marka.Content = ile + poliska;
        }

        private void ford_Checked(object sender, RoutedEventArgs e)
        {
            if (ford.IsChecked == true)
                ile = ile + 2000;
            else
                ile = ile - 2000;
            cena_marka.Content = ile + poliska;
        }

        private void ferari_Checked(object sender, RoutedEventArgs e)
        {
            if (ferari.IsChecked == true)
                ile = ile + 3000;
            else
                ile = ile - 3000;
            cena_marka.Content = ile + poliska;
        }

       

        private void radio_Checked(object sender, RoutedEventArgs e)
        {
            if (radio.IsChecked == true)
                ile = ile + 1000;
            else
                ile = ile - 1000;
            cena_marka.Content = ile + poliska;
        }

        private void klimatyzacja_Checked(object sender, RoutedEventArgs e)
        {
            if (klimatyzacja.IsChecked == true)
                ile = ile + 2000;
            else
                ile = ile - 2000;
            cena_marka.Content = ile + poliska;
        }

        private void auto_skrzynia_Checked(object sender, RoutedEventArgs e)
        {
            if (auto_skrzynia.IsChecked == true)
                ile = ile + 3000;
            else
                ile = ile - 3000;
            cena_marka.Content = ile + poliska;
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void cena_polisy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(cena_polisy.Text, out poliska))
            {
                poliska = 0;
            }
            cena_marka.Content = ile + poliska;

        }
    }
}

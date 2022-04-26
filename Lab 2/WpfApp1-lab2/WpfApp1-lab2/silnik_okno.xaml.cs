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
    /// Logika interakcji dla klasy silnik_okno.xaml
    /// </summary>
    public partial class silnik_okno : Window
    {
        public int ile = 0;
        public int moc_silnika = 0;

        public silnik_okno(int suma_cen)
        {
            InitializeComponent();
            this.ile = suma_cen;
            cena_silnik.Content = ile + moc_silnika;
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void diesel_Checked(object sender, RoutedEventArgs e)
        {
            if (diesel.IsChecked == true)
                ile = ile + 1000;
            else
                ile = ile - 1000;
            cena_silnik.Content = ile + moc_silnika;
        }

        private void gaz_Checked(object sender, RoutedEventArgs e)
        {
            if (gaz.IsChecked == true)
                ile = ile + 2000;
            else
                ile = ile - 2000;
            cena_silnik.Content = ile + moc_silnika;
        }

        private void hybryda_Checked(object sender, RoutedEventArgs e)
        {
            if (hybryda.IsChecked == true)
                ile = ile + 3000;
            else
                ile = ile - 3000;
            cena_silnik.Content = ile + moc_silnika;
        }

        private void moc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (moc.SelectedIndex == 0)
                moc_silnika = 1000;
            else if (moc.SelectedIndex == 1)
                moc_silnika = 2000;
           else if (moc.SelectedIndex == 2)
                moc_silnika = 3000;

            cena_silnik.Content = ile + moc_silnika;
        }
    }
}

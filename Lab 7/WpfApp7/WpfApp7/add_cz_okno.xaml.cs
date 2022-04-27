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

namespace WpfApp7
{
    /// <summary>
    /// Logika interakcji dla klasy add_cz_okno.xaml
    /// </summary>
    public partial class add_cz_okno : Window
    {
        public string imie = "imie";
        public string nazwisko = "nazwisko";

        public add_cz_okno(string dane_imie, string dane_nazwisko)
        {
            this.imie = dane_imie;
            this.nazwisko = dane_nazwisko;
            InitializeComponent();
        }

        private void text_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            imie = text_name.Text;
        }

        private void text_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            nazwisko = text_username.Text;
        }

        private void add2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

   
    }
}

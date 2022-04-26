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

namespace WpfApp6
{
    /// <summary>
    /// Logika interakcji dla klasy add_okno.xaml
    /// </summary>
    public partial class add_okno : Window
    {
        public string imie = "imie";
        public int countt = 0;

        public add_okno(string dane_imie, int dane_count)
        {
            this.imie = dane_imie;
            this.countt = dane_count;
            InitializeComponent();
        }

        private void imie_nazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {
            imie = imie_nazwisko.Text;
        }

        private void counting_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(counting.Text, out countt))
            {
                countt = 0;
            }

        }

        private void add2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

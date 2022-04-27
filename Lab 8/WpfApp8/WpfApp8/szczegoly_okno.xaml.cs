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

namespace WpfApp8
{
    /// <summary>
    /// Logika interakcji dla klasy szczegoly_okno.xaml
    /// </summary>
    public partial class szczegoly_okno : Window
    {
        public szczegoly_okno(string kod_ICAO, string kod_IATA, string l_pasazerow, string wojew, string mias)
        {
            InitializeComponent();

            if (!String.IsNullOrEmpty(kod_ICAO))
            {
                informacje.Text += "Kod ICAO: " + kod_ICAO + "\n";
            }
            if (!String.IsNullOrEmpty(kod_IATA))
            {
                informacje.Text += "Kod IATA: " + kod_IATA + "\n";
            }
            if (!String.IsNullOrEmpty(l_pasazerow))
            {
                informacje.Text += "Liczba pasażerów: " + l_pasazerow + "\n";
            }
            if (!String.IsNullOrEmpty(wojew))
            {
                informacje.Text += "Województwo: " + wojew + "\n";
            }
            if (!String.IsNullOrEmpty(mias))
            {
                informacje.Text += "Miasto: " + mias + "\n";
            }

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

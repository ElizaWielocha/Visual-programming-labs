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
using Microsoft.Win32;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Reflection;


namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IList<Lotnisko> PortList = new List<Lotnisko>();
        public string ktore_lotnisko;
        public string kod_ICAO;
        public string kod_IATA;
        public string l_pasazerow;
        public string wojew;
        public string mias;

        public MainWindow()
        {
            InitializeComponent();

            MessageBoxResult result = MessageBox.Show("Wybierz plik, z którego ma być wczytana lista portów lotniczych.", "Wybierz");
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string inputPathCSV = fileDialog.FileName;

            string[] lines = File.ReadAllLines(inputPathCSV);

            for(int i = 0; i < lines.Length; i++)
            {
                string x = lines[i];
                
                if(x.EndsWith("\""))
                {
                    string[] data = x.Split(',');

                    Lotnisko nowe = new Lotnisko();
                    nowe.miasto = data[0];
                    nowe.wojewodztwo = data[1];
                    nowe.ICAO = data[2];
                    nowe.IATA = data[3];
                    nowe.nazwa = data[4];
                    nowe.liczba_pasazerow = data[5];
                    nowe.zmiana = data[6];
                        
                    PortList.Add(nowe);
                }
                else
                {
                    string y = lines[i + 1];
                    x = x + y;
                    x.Replace("\n", "");
                    string[] data = x.Split(',');

                    Lotnisko nowe = new Lotnisko();
                    nowe.miasto = data[0];
                    nowe.wojewodztwo = data[1];
                    nowe.ICAO = data[2];
                    nowe.IATA = data[3];
                    nowe.nazwa = data[4];
                    nowe.liczba_pasazerow = data[5];
                    nowe.zmiana = data[6];
                        
                    PortList.Add(nowe);
                    i = i + 1;
                }
            }

            PortList.RemoveAt(0);
            foreach (Lotnisko Object in PortList)
            {
                lotniska.Items.Add(Object.nazwa);  // wypisanie w textboxie nazw lotnisk
            } 

        }

        private void lotniska_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ktore_lotnisko = (string)lotniska.SelectedItem;
        }

        private void icao_Checked(object sender, RoutedEventArgs e)
        {
            if (icao.IsChecked == true)
            {
                foreach (Lotnisko Object in PortList)
                {
                    if (Object.nazwa == ktore_lotnisko)
                    {
                        kod_ICAO = Object.ICAO;
                    }
                }
            }
            else
            {
                kod_ICAO = string.Empty;
            }
        }

        private void iata_Checked(object sender, RoutedEventArgs e)
        {
            if (iata.IsChecked == true)
            {
                foreach (Lotnisko Object in PortList)
                {
                    if (Object.nazwa == ktore_lotnisko)
                    {
                        kod_IATA = Object.IATA;
                    }
                }
            }
            else
            {
                kod_IATA = string.Empty;
            }
        }

        private void liczba_Checked(object sender, RoutedEventArgs e)
        {
            if (liczba.IsChecked == true)
            {
                foreach (Lotnisko Object in PortList)
                {
                    if (Object.nazwa == ktore_lotnisko)
                    {
                        l_pasazerow = Object.liczba_pasazerow;
                    }
                }
            }
            else
            {
                l_pasazerow = string.Empty;
            }
        }

        private void wojewodztwo_Checked(object sender, RoutedEventArgs e)
        {
            if (wojewodztwo.IsChecked == true)
            {
                foreach (Lotnisko Object in PortList)
                {
                    if (Object.nazwa == ktore_lotnisko)
                    {
                        wojew = Object.wojewodztwo;
                    }
                }
            }
            else
            {
                wojew = string.Empty;
            }
        }

        private void miasto_Checked(object sender, RoutedEventArgs e)
        {
            if (miasto.IsChecked == true)
            {
                foreach (Lotnisko Object in PortList)
                {
                    if (Object.nazwa == ktore_lotnisko)
                    {
                        mias = Object.miasto;
                    }
                }
            }
            else
            {
                mias = string.Empty;
            }
        }

        private void szczegoly_Click(object sender, RoutedEventArgs e)
        {
            szczegoly_okno window = new szczegoly_okno(kod_ICAO, kod_IATA, l_pasazerow, wojew, mias);
            window.ShowDialog();

        }

    }

    public class Lotnisko
    {
        public string miasto { get; set; }

        public string wojewodztwo { get; set; }

        public string ICAO { get; set; }

        public string IATA { get; set; }

        public string nazwa { get; set; }

        public string liczba_pasazerow { get; set; }

        public string zmiana { get; set; }
    }

}

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

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string wybrane_zwierze;
        string wybrany_poziom;

        public MainWindow()
        {
            InitializeComponent();

            zwierze.Items.Add("mysz");
            zwierze.Items.Add("ryba");
            zwierze.Items.Add("kot");
            zwierze.Items.Add("krokodyl");

            trudnosc.Items.Add("łatwy");
            trudnosc.Items.Add("normalny");
            trudnosc.Items.Add("trudny");
        }

        private void zwierze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybrane_zwierze = (string)zwierze.SelectedItem;
        }

        private void trudnosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybrany_poziom = (string)trudnosc.SelectedItem;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if(wybrany_poziom == "łatwy")
            {
                okno3x3 window = new okno3x3(wybrane_zwierze);
                window.ShowDialog();
            }
            if (wybrany_poziom == "normalny")
            {
                okno4x4 window = new okno4x4(wybrane_zwierze);
                window.ShowDialog();
            }
            if (wybrany_poziom == "trudny")
            {
                okno5x5 window = new okno5x5(wybrane_zwierze);
                window.ShowDialog();
            }
        }
    }
}

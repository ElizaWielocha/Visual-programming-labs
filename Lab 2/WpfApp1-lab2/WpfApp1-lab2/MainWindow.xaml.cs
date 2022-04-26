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

namespace WpfApp1_lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int suma_cen = 0;

        public MainWindow()
        {
            InitializeComponent();
            cena.Content = suma_cen;
        }




        private void marka_Click(object sender, RoutedEventArgs e)
        {
            marka_okno window = new marka_okno(suma_cen);
            window.ShowDialog();
            suma_cen = window.ile + window.poliska;
            cena.Content = suma_cen;
        }
        
        

        private void silnik_Click(object sender, RoutedEventArgs e)
        {
            silnik_okno window = new silnik_okno(suma_cen);
            window.ShowDialog();
            suma_cen = window.ile;
            cena.Content = suma_cen;
        }
    }
}

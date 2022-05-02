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

namespace WpfApp12
{
    /// <summary>
    /// Logika interakcji dla klasy win.xaml
    /// </summary>
    public partial class win : Window
    {
        string wybrane_zwierze;

        string adres_myszy = @"https://as1.ftcdn.net/jpg/02/99/27/58/1000_F_299275834_F7210rOqmkfpKS2iJRJ1pUnmMZWB0PB6.jpg";
        string adres_ryby = @"https://graphicriver.img.customer.envatousercontent.com/files/234055097/CartoonFishB%20p.jpg?auto=compress%2Cformat&q=80&fit=crop&crop=top&max-h=8000&max-w=590&s=947c998825e325e1645dd04be06f53ef";
        string adres_kota = @"https://png.pngtree.com/element_our/20190522/ourlarge/pngtree-cute-cartoon-cat-image_1075212.jpg";
        

        public win(string wybrane_zwierze)
        {
            InitializeComponent();
            this.wybrane_zwierze = wybrane_zwierze;

            if(wybrane_zwierze == "mysz")
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(adres_myszy, UriKind.Absolute);
                bitmap.EndInit();

                obrazek.Source = bitmap;
            }
            else if(wybrane_zwierze == "ryba")
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(adres_ryby, UriKind.Absolute);
                bitmap.EndInit();

                obrazek.Source = bitmap;
            }
            else
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(adres_kota, UriKind.Absolute);
                bitmap.EndInit();

                obrazek.Source = bitmap;
            }

            zwierze.Content = wybrane_zwierze.ToUpper() + "!";
        }
    }
}

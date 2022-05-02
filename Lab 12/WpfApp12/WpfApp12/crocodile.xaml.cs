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
    /// Logika interakcji dla klasy crocodile.xaml
    /// </summary>
    public partial class crocodile : Window
    {
        int are_u_winner;
        string adres_krokodyla = @"https://image.freepik.com/darmowe-wektory/sliczna-krokodyl-kreskowka_33070-2668.jpg";
        string straszny_adres_krokodyla = @"https://media.istockphoto.com/vectors/crocodile-cute-cartoon-vector-id696155108";
        public crocodile()
        {
            InitializeComponent();
            Random los = new Random();
            are_u_winner = los.Next(0, 2); // creates a random number between 0 and 1

            if (are_u_winner == 1)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(adres_krokodyla, UriKind.Absolute);
                bitmap.EndInit();

                obrazek.Source = bitmap;
                co.Content = "WYGRANA!";
            }
            else
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(straszny_adres_krokodyla, UriKind.Absolute);
                bitmap.EndInit();

                obrazek.Source = bitmap;
                co.Content = "CIĘ ZJADŁ :(";
            }
        }
    }
}

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
using System.Windows.Threading;

namespace WpfApp12
{
    /// <summary>
    /// Logika interakcji dla klasy okno3x3.xaml
    /// </summary>
    public partial class okno3x3 : Window
    {
        private DispatcherTimer dispatcherTimer;
        string wybrane_zwierze;
        int id;
        string panel_wygrany = "nie";

        string adres_myszy = @"https://as1.ftcdn.net/jpg/02/99/27/58/1000_F_299275834_F7210rOqmkfpKS2iJRJ1pUnmMZWB0PB6.jpg";
        string adres_ryby = @"https://graphicriver.img.customer.envatousercontent.com/files/234055097/CartoonFishB%20p.jpg?auto=compress%2Cformat&q=80&fit=crop&crop=top&max-h=8000&max-w=590&s=947c998825e325e1645dd04be06f53ef";
        string adres_kota = @"https://png.pngtree.com/element_our/20190522/ourlarge/pngtree-cute-cartoon-cat-image_1075212.jpg";
        string adres_krokodyla = @"https://image.freepik.com/darmowe-wektory/sliczna-krokodyl-kreskowka_33070-2668.jpg";
        

        public okno3x3(string wybrane_zwierze)
        {
            this.wybrane_zwierze = wybrane_zwierze;
            InitializeComponent();
            Random rnd = new Random();
            id = rnd.Next(1, 10); // creates a random number between 1 and 9

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }

        void Odkrywanie(string wybrane_zwierze,int id, Button panel)
        {
            string adres_zwierze;
            if(wybrane_zwierze == "mysz")
            {
                adres_zwierze = adres_myszy;
            }
            else if(wybrane_zwierze == "ryba")
            {
                adres_zwierze = adres_ryby;
            }
            else if(wybrane_zwierze == "kot")
            {
                adres_zwierze = adres_kota;
            }
            else
            {
                adres_zwierze = adres_krokodyla;
            }
            if (panel.Name[6].ToString() == id.ToString())
            {
                panel_wygrany = "tak";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(adres_zwierze, UriKind.Absolute);
                bitmap.EndInit();

                foreach (var tb in grid.Children)
                {
                    if (tb is Image)
                    {
                        Image tbb = (Image)tb;
                        if (tbb.Name == "image" + id.ToString())
                        {
                            tbb.Source = bitmap;
                        }
                    }
                }
            }
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button1);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button2.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button2);
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            button3.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button3);
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            button4.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button4);
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            button5.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button5);
        }
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            button6.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button6);
        }
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            button7.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button7);
        }
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            button8.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button8);
        }
        private void button9_Click(object sender, RoutedEventArgs e)
        {
            button9.Visibility = Visibility.Collapsed;
            Odkrywanie(wybrane_zwierze, id, button9);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Things which happen after 1 timer interval
            if(panel_wygrany == "tak" && wybrane_zwierze != "krokodyl")
            {
                win window = new win(wybrane_zwierze);
                window.ShowDialog();
            }
            if(panel_wygrany == "tak" && wybrane_zwierze == "krokodyl")
            {
                crocodile window = new crocodile();
                window.ShowDialog();
            }
            if(panel_wygrany == "nie")
            {
                loose window = new loose();
                window.ShowDialog();
            }
            
            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }

      
    }
}

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
    /// Logika interakcji dla klasy loose.xaml
    /// </summary>
    public partial class loose : Window
    {
        public loose()
        {
            InitializeComponent();

            string sad_adres = @"https://img.redro.pl/plakaty/gloomy-sad-emoji-emoticon-looking-down-700-209718796.jpg";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(sad_adres, UriKind.Absolute);
            bitmap.EndInit();

            smuteczek.Source = bitmap;
        }
    }
}

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
    /// Logika interakcji dla klasy wypozycz_okno.xaml
    /// </summary>
    public partial class wypozycz_okno : Window
    {

        public string kto;
        public string co;

        public wypozycz_okno(string wypozycz_kto, string wypozycz_co)
        {
            InitializeComponent();
            this.kto = wypozycz_kto;
            this.co = wypozycz_co;
        }

        private void text_kto_w_TextChanged(object sender, TextChangedEventArgs e)
        {
            kto = text_kto_w.Text;
        }

        private void text_co_w_TextChanged(object sender, TextChangedEventArgs e)
        {
            co = text_co_w.Text;
        }

        private void wypozycz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

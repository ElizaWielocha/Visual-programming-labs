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
    /// Logika interakcji dla klasy oddaj_okno.xaml
    /// </summary>
    public partial class oddaj_okno : Window
    {

        public string kto;
        public string co;

        public oddaj_okno(string oddaj_kto, string oddaj_co)
        {
            this.kto = oddaj_kto;
            this.co = oddaj_co;
            InitializeComponent();
        }

        private void text_kto_o_TextChanged(object sender, TextChangedEventArgs e)
        {
            kto = text_kto_o.Text;
        }

        private void text_co_o_TextChanged(object sender, TextChangedEventArgs e)
        {
            co = text_co_o.Text;
        }

        private void oddaj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

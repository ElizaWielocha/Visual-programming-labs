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
    /// Logika interakcji dla klasy add_ks_okno.xaml
    /// </summary>
    public partial class add_ks_okno : Window
    {
        public string tytul = "tytul";
        public string autor = "autor";

        public add_ks_okno(string dane_tytul, string dane_autor)
        {
            this.tytul = dane_tytul;
            this.autor = dane_autor;
            InitializeComponent();
        }

        private void text_title_TextChanged(object sender, TextChangedEventArgs e)
        {
            tytul = text_title.Text;
        }

        private void text_autor_TextChanged(object sender, TextChangedEventArgs e)
        {
            autor = text_autor.Text;
        }

        private void add2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

using System;
using System.IO;
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

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string dane_imie;
        public int dane_count;
        public int id_num = 1;
        //List<User> items = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
        
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            add_okno window = new add_okno(dane_imie, dane_count);
            window.ShowDialog();

            dane_imie = window.imie;
            dane_count = window.countt;

            lvUsers.Items.Add(new User() { name = dane_imie, id = id_num++, count = dane_count });
            lvUsers.Items.Refresh();
        }

        private void zapisz_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "CSV file (*.csv)|Text file (*.txt)|*.txt|*.csv|All files (*.*)|*.*";

            fileDialog.ShowDialog();
            string savePathCSV = fileDialog.FileName;

            using (var output = new StreamWriter(savePathCSV))
            {
                foreach (User item in lvUsers.Items)
                {
                    output.WriteLine("{0};{1};{2}", item.name, item.id, item.count);
                }
            }
        }

        private void odczyt_Click(object sender, RoutedEventArgs e)
        {
            lvUsers.Items.Clear();

            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            string inputPathCSV = fileDialog.FileName;

            string[] lines = File.ReadAllLines(inputPathCSV);

            foreach (var item in lines)
            {
                string[] data = item.Split(';');

                this.lvUsers.Items.Add(new User { name = data[0], id = id_num++, count = Int32.Parse(data[1]) });
            }
        }
    }

    public class User
    {
        public string name { get; set; }

        public int id { get; set; }

        public int count { get; set; }
    }

   
}

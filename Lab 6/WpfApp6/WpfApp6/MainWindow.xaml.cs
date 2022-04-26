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
using System.Xml;
using System.Xml.Serialization;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.ExtendedProperties;
using System.Configuration;
using System.Collections.Specialized;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Reflection;


namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string dane_imie;
        public int dane_count;
        public int id_num = 1;
        IList<User> dataList = new List<User>();
        public string input;

        public MainWindow()
        {
            InitializeComponent();

            NameValueCollection sAll;                           // wczytywanie ostatniego używanego pliku
            sAll = ConfigurationManager.AppSettings;
            string previous = sAll.Get("previous");

            if (previous != "")
            {
                id_num = 1;
                string inputPathCSV = previous;
                dataList = (IList<User>)Deserialize(dataList, inputPathCSV);


                foreach (User dataObject in dataList)
                {
                    this.lvUsers.Items.Add(dataObject);
                }
            }
            
        }

        private void add_Click(object sender, RoutedEventArgs e)          // dodawanie nowych osob do listy
        {
            add_okno window = new add_okno(dane_imie, dane_count);
            if (window.ShowDialog() ?? true)
            {
                dane_imie = window.imie;
                dane_count = window.countt;

                User new_guy = new User();
                new_guy.name = dane_imie;
                new_guy.id = id_num++;
                new_guy.count = dane_count;

                dataList.Add(new_guy);
                lvUsers.Items.Add(new_guy);
                lvUsers.Items.Refresh();
            }
            
        }


        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)          // metoda serializacji
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }

        private void zapisz_Click(object sender, RoutedEventArgs e)           // zapisywanie pliku z użyciem metody serializacji
        {
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.Filter = "XML-File | *.xml";
            if (fileDialog.ShowDialog() ?? true)
            {
                string savePathCSV = fileDialog.FileName;
                SerializeToXml(dataList, savePathCSV);
            }

        }

        public static object Deserialize<T>(T anyobject, string xmlFilePath)              // metoda deserializacji
        {
            using (TextReader reader = new StreamReader(xmlFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(anyobject.GetType());
                return (T)serializer.Deserialize(reader);
            }
        }


        private void odczyt_Click(object sender, RoutedEventArgs e)              // odczyt pliku z użyciem metody deserializacji
        {

            lvUsers.Items.Clear();
            id_num = 1;

            FileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() ?? true)
            {
                fileDialog.RestoreDirectory = true;

                string inputPathCSV = fileDialog.FileName;
                dataList = (IList<User>)Deserialize(dataList, inputPathCSV);


                foreach (User dataObject in dataList)
                {
                    this.lvUsers.Items.Add(dataObject);
                }

                Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);   // zapis PATHa ostatniego ladowanego pliku
                configuration.AppSettings.Settings["previous"].Value = inputPathCSV;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)           // zamkniecie okna i zapytanie czy chcesz zapisać
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać listę?", "Jesteś pewny?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog fileDialog = new SaveFileDialog();

                    fileDialog.Filter = "XML-File | *.xml";
                    if (fileDialog.ShowDialog() ?? true)
                    {
                        string savePathCSV = fileDialog.FileName;
                        SerializeToXml(dataList, savePathCSV);    
                    }
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void find_TextChanged(object sender, TextChangedEventArgs e)          // wpisywanie szukanego tekstu i ladowanie do zmiennej
        {
            input = find.Text;   
        }

        private void szukaj_button_Click(object sender, RoutedEventArgs e)         // szukanie po obiektach listy i wyswietlanie tylko tego znalezionego
        {
            if (Regex.IsMatch(input, @"^\d+$") == true)       // po countach
            {
                foreach (User dataObject in dataList)
                {
                    if (dataObject.count == Int32.Parse(input))
                    {
                        lvUsers.Items.Clear();
                        this.lvUsers.Items.Add(dataObject);
                        lvUsers.Items.Refresh();
                    }
                }
            }
            else                                               // po imionach
            {
                foreach (User dataObject in dataList)
                {
                    if (dataObject.name.ToLower() == input.ToLower())
                    {
                        lvUsers.Items.Clear();
                        this.lvUsers.Items.Add(dataObject);
                        lvUsers.Items.Refresh();
                    }
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)         // powrot do pierwotnej listy
        {
            lvUsers.Items.Clear();
            foreach (User dataObject in dataList)
            {
                this.lvUsers.Items.Add(dataObject);
            }
            lvUsers.Items.Refresh();
        }
    }

    [Serializable]
    public class User        // klasa przechowujaca dane o nowo dodanym obiekcie/osobie
    {
        public string name { get; set; }

        public int id { get; set; }

        public int count { get; set; }
    }


}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Drawing;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int folderPathLength;      // długość scieżki do folderu
        string[] dirFiles;         // lista plików znajdujących się w wybranym folderze
        string wybrana_piosenka;   // wybrana przez użytkownika piosenka z Listboxa
        MediaPlayer Sound = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            MessageBoxResult result = MessageBox.Show("Wybierz katalog zawierający piosenki świąteczne", "Wybierz");

            OpenFileDialog openFileDialog = new OpenFileDialog();
   
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FileName = "Wybierz folder";

            openFileDialog.ShowDialog();
            string folderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            folderPathLength = folderPath.Length;

            dirFiles = Directory.GetFiles(folderPath);
            foreach (string file in dirFiles)
            {
                string piosenka = file.Substring(folderPathLength + 1, file.Length - folderPathLength - 1);
                piosenki.Items.Add(piosenka);
            }

        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            foreach (string file in dirFiles)
            {
                if(file.Substring(folderPathLength + 1, file.Length - folderPathLength - 1) == wybrana_piosenka)
                {
                    Sound.Open(new Uri(file));
                    Sound.Play();
                }
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            Sound.Stop();
        }

        private void piosenki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybrana_piosenka = (string)piosenki.SelectedItem;
        }
    }
}

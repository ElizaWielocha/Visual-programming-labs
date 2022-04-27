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
using System.Configuration;
using System.Collections.Specialized;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Reflection;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string dane_imie;
        public string dane_nazwisko;
        public string dane_tytul;
        public string dane_autor;


        public int id_num = 1;
        public int id_num_ks = 1;

        IList<User> UserList = new List<User>();
        IList<Book> BookList = new List<Book>();
        IList<Wypozyczenie> BorrowedList = new List<Wypozyczenie>();
        public string input;

        public MainWindow()
        {
            InitializeComponent();

            UserList.Clear();
            BookList.Clear();
            BorrowedList.Clear();

            MessageBoxResult result = MessageBox.Show("Masz zapisany plik z tego projektu? \nJeśli tak, wybierz 'Tak'. \nJeśli nie, wybierz 'Nie'.", "Wybierz", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();
                string inputPathCSV = fileDialog.FileName;

                string[] lines = File.ReadAllLines(inputPathCSV);

                for (int i = 0; i < lines.Length; i++)
                {
                    string x = lines[i];
                    string[] data = x.Split(';');

                    if (data.Length == 3)
                    {
                        User czytelnik = new User();

                        czytelnik.name = data[0];
                        czytelnik.username = data[1];
                        czytelnik.id = Int32.Parse(data[2]);

                        UserList.Add(czytelnik);
                    }
                    else if (data.Length == 4)
                    {
                        Book ksiazka = new Book();

                        ksiazka.title = data[0];
                        ksiazka.autor = data[1];
                        ksiazka.id = Int32.Parse(data[2]);
                        ksiazka.borrowed = data[3];

                        BookList.Add(ksiazka);
                    }
                    else if (data.Length == 5)
                    {
                        Wypozyczenie nowe = new Wypozyczenie();

                        nowe.title = data[0];
                        nowe.autor = data[1];
                        nowe.username = data[2];
                        nowe.book_id = Int32.Parse(data[3]);
                        nowe.user_id = Int32.Parse(data[4]);

                        BorrowedList.Add(nowe);
                    }
                }
                foreach (User dataObject in UserList)
                {
                    this.lvUsers.Items.Add(dataObject);
                }
                foreach (Book dataObject in BookList)
                {
                    this.Books.Items.Add(dataObject);
                }
            }
        }

        private void dodaj_cz_Click(object sender, RoutedEventArgs e)
        {
            add_cz_okno window = new add_cz_okno(dane_imie, dane_nazwisko);
            window.ShowDialog();

            dane_imie = window.imie;
            dane_nazwisko = window.nazwisko;

            User new_guy = new User();
            new_guy.name = dane_imie;
            new_guy.username = dane_nazwisko;
            new_guy.id = id_num++;

            UserList.Add(new_guy);
            lvUsers.Items.Add(new_guy);
            lvUsers.Items.Refresh();

        }

        private void dodaj_ks_Click(object sender, RoutedEventArgs e)
        {
            add_ks_okno window = new add_ks_okno(dane_tytul, dane_autor);
            window.ShowDialog();

            dane_tytul = window.tytul;
            dane_autor = window.autor;

            Book new_pos = new Book();
            new_pos.title = dane_tytul;
            new_pos.autor = dane_autor;
            new_pos.id = id_num_ks++;
            new_pos.borrowed = "---";

            BookList.Add(new_pos);
            Books.Items.Add(new_pos);
            Books.Items.Refresh();
        }


        public string wypozycz_kto;
        public string wypozycz_co;

        private void wypozycz_Click(object sender, RoutedEventArgs e)
        {
            wypozycz_okno window = new wypozycz_okno(wypozycz_kto, wypozycz_co);
            window.ShowDialog();

            wypozycz_kto = window.kto;
            wypozycz_co = window.co;

            Wypozyczenie nowe = new Wypozyczenie();

            foreach (User dataObject in UserList)
            {
                if (Int32.Parse(wypozycz_kto) == dataObject.id)
                {
                    foreach (Book Object in BookList)
                    {
                        if (Int32.Parse(wypozycz_co) == Object.id)
                        {
                            nowe.username = dataObject.username;
                            nowe.user_id = dataObject.id;
                            nowe.autor = Object.autor;
                            nowe.book_id = Object.id;
                            nowe.title = Object.title;
                            BorrowedList.Add(nowe);

                            Object.borrowed = dataObject.id.ToString();
                        }
                    }

                }
            }

            MessageBoxResult result = MessageBox.Show("Książka została wypożyczona!", "Gratulacje!");

            Books.Items.Clear();
            foreach (Book dataObject in BookList)
            {
                Books.Items.Add(dataObject);
                Books.Items.Refresh();
            }

        }

        public string oddaj_kto;
        public string oddaj_co;

        private void oddaj_Click(object sender, RoutedEventArgs e)
        {
            oddaj_okno window = new oddaj_okno(oddaj_kto, oddaj_co);
            window.ShowDialog();

            oddaj_kto = window.kto;
            oddaj_co = window.co;

            foreach (Wypozyczenie dataObject in BorrowedList.ToList())
            {
                if (Int32.Parse(oddaj_co) == dataObject.book_id)
                {
                    if (Int32.Parse(oddaj_kto) == dataObject.user_id)
                    {
                        foreach (Book Object in BookList)
                        {
                            if (Int32.Parse(oddaj_co) == Object.id)
                            {
                                Object.borrowed = "---";
                            }
                        }
                        BorrowedList.Remove(dataObject);
                    }
                }
            }

            MessageBoxResult result = MessageBox.Show("Książka została oddana!", "Gratulacje!");

            Books.Items.Clear();
            foreach (Book dataObject in BookList)
            {
                Books.Items.Add(dataObject);
                Books.Items.Refresh();
            }

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)           // zamkniecie okna i zapytanie czy chcesz zapisać
        {

            MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać plik?", "Zamykanie", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "txt File | *.txt";

                if (fileDialog.ShowDialog() ?? true)
                {
                    string savePathCSV = fileDialog.FileName;

                    using (var output = new StreamWriter(savePathCSV))
                    {
                        foreach (User item in UserList)
                        {
                            output.WriteLine("{0};{1};{2}", item.name, item.username, item.id);
                        }
                        foreach (Book item in BookList)
                        {
                            output.WriteLine("{0};{1};{2};{3}", item.title, item.autor, item.id, item.borrowed);
                        }
                        foreach (Wypozyczenie item in BorrowedList)
                        {
                            output.WriteLine("{0};{1};{2};{3};{4}", item.title, item.autor, item.username, item.book_id, item.user_id);
                        }
                    }
                }
            }
        }

        [Serializable]
        public class User        // klasa przechowujaca dane o nowo dodanej osobie
        {
            public string name { get; set; }

            public string username { get; set; }

            public int id { get; set; }
        }


        [Serializable]
        public class Book        // klasa przechowujaca dane o nowo dodanej książce
        {
            public string title { get; set; }

            public string autor { get; set; }

            public int id { get; set; }

            public string borrowed { get; set; }
        }


        [Serializable]
        public class Wypozyczenie        // klasa przechowujaca dane o wypozyczeniu
        {
            public string title { get; set; }

            public string autor { get; set; }

            public string username { get; set; }

            public int book_id { get; set; }

            public int user_id { get; set; }
        }

       
    }
}

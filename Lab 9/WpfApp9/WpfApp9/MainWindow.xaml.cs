using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string safe_kierunek;
        public string safe_zakres;
        public string safe_profil;
        public string safe_forma;
        public string safe_poziom;

        public string stud1_kto;
        public string stud1_numer;
        public string stud1_data;

        public string stud2_kto;
        public string stud2_numer;
        public string stud2_data;

        public string stud3_kto;
        public string stud3_numer;
        public string stud3_data;

        public string stud4_kto;
        public string stud4_numer;
        public string stud4_data;

        public string safe_tytul;
        public string safe_wersja_ang;
        public string safe_dane;
        public string safe_zakres_pracy;
        public string safe_termin;
        public string safe_promotor;
        public string safe_j_organ;
        public string safe_podpis_dyr;
        public string safe_data_pod_dziekan;

        string formula;
        public MainWindow()
        {
            InitializeComponent();

            jaka_praca.Items.Add("licencjackiej");
            jaka_praca.Items.Add("inżynierskiej");
            jaka_praca.Items.Add("magisterskiej");

            formula = "Zobowiązuję/zobowiązujemy się samodzielnie wykonać pracę w zakresie wyspecyfikowanym niżej. Wszystkie elementy (m.in. rysunki, tabele, cytaty, programy komputerowe, urządzenia itp.), które zostaną wykorzystane w pracy, a nie będą mojego/naszego autorstwa będą w odpowiedni sposób zaznaczone i będzie podane źródło ich pochodzenia. \n \n" +
                "Jeżeli w wyniku realizacji pracy zostanie dokonany wynalazek, wzór użytkowy, wzór przemysłowy, znak towarowy, prawa do rozwiązań przysługiwać będą Politechnice Poznańskiej. Prawo to zostanie uregulowane odrębną umową. \n" +
                "Oświadczam, iż o wyniku prac wskazanych powyżej, a także o innych, w tym tych, które mogą być przedmiotem tajemnicy Politechniki Poznańskiej, niezwłocznie powiadomię promotora pracy.\n" +
                "Zobowiązuję się ponadto do zachowania w tajemnicy wszystkich informacji technicznych, technologicznych, organizacyjnych, uzyskanych w Politechnice Poznańskiej w okresie od daty rozpoczęcia realizacji prac do 5 lat od daty zakończenia wykonania prac";
            formulka.Text = formula;

            MessageBoxResult result = MessageBox.Show("Czy wczytać poprzedni plik?", "Wybierz", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.Filter = "CSV file (.csv)|*.csv|Text file (.txt)|*.txt";

                    fileDialog.ShowDialog();
                    string inputPathCSV = fileDialog.FileName;

                    string[] lines = File.ReadAllLines(inputPathCSV);

                    string[] data = lines[0].Split(';'); // wczytuje info poczatkowe (kierunek, rodzaj studiow, itp)
                    kierunek.Text = data[0];
                    zakres.Text = data[1];
                    profil.Text = data[2];
                    forma.Text = data[3];
                    poziom.Text = data[4];

                    data = lines[1].Split(";");  // wczytuje pierwszego studenta
                    student1.Text = data[0];
                    nr_alb1.Text = data[1];
                    data_pod1.Text = data[2];

                    data = lines[2].Split(";");  // drugi student
                    student2.Text = data[0];
                    nr_alb2.Text = data[1];
                    data_pod2.Text = data[2];

                    data = lines[3].Split(";");  // trzeci student
                    student3.Text = data[0];
                    nr_alb3.Text = data[1];
                    data_pod3.Text = data[2];

                    data = lines[4].Split(";");  // czwarty student
                    student4.Text = data[0];
                    nr_alb4.Text = data[1];
                    data_pod4.Text = data[2];

                    data = lines[5].Split(";");  // wczytuje info o pracy licencjackiej oraz podpisy 
                    tytul.Text = data[0];
                    wersja_ang.Text = data[1];
                    dane_wej.Text = data[2];
                    zakres_pracy.Text = data[3];
                    termin.Text = data[4];
                    promotor.Text = data[5];
                    j_organ.Text = data[6];
                    podpis_dyr.Text = data[7];
                    data_pod_dziekan.Text = data[8];
                    jaka_praca.SelectedItem = data[9];

                    break;

                case MessageBoxResult.No:
                    break;
            }

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result1 = MessageBox.Show("Czy chcesz zapisać listę?", "Jesteś pewny?", MessageBoxButton.YesNo);
            switch (result1)
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog fileDialog = new SaveFileDialog();
                    fileDialog.Filter = "CSV file (.csv)|*.csv|Text file (.txt)|*.txt";

                    fileDialog.ShowDialog();
                    string savePathCSV = fileDialog.FileName;
                    using (var output = new StreamWriter(savePathCSV))
                    {

                        output.WriteLine("{0};{1};{2};{3};{4}", safe_kierunek, safe_zakres, safe_profil, safe_forma, safe_poziom);
                        output.WriteLine("{0};{1};{2}", stud1_kto, stud1_numer, stud1_data);
                        output.WriteLine("{0};{1};{2}", stud2_kto, stud2_numer, stud2_data);
                        output.WriteLine("{0};{1};{2}", stud3_kto, stud3_numer, stud3_data);
                        output.WriteLine("{0};{1};{2}", stud4_kto, stud4_numer, stud4_data);
                        output.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", safe_tytul, safe_wersja_ang, safe_dane, safe_zakres_pracy, safe_termin, safe_promotor, safe_j_organ, safe_podpis_dyr, safe_data_pod_dziekan, jaka_praca.SelectedItem);
                    }
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void kierunek_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_kierunek = kierunek.Text;
        }

        private void zakres_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_zakres = zakres.Text;
        }

        private void profil_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_profil = profil.Text;
        }

        private void forma_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_forma = forma.Text;
        }

        private void poziom_TextChanged(object sender, TextChangedEventArgs e)
        {
           safe_poziom = poziom.Text;
        }

        private void student1_TextChanged(object sender, TextChangedEventArgs e)
        {
           stud1_kto = student1.Text;

        }

        private void nr_alb1_TextChanged(object sender, TextChangedEventArgs e)
        {
           stud1_numer = nr_alb1.Text;
        }

        private void data_pod1_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud1_data = data_pod1.Text;
        }


        private void student2_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud2_kto = student2.Text;
        }

        private void nr_alb2_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud2_numer = nr_alb2.Text;
        }

        private void data_pod2_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud2_data = data_pod2.Text;
        }


        private void student3_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud3_kto = student3.Text;
        }

        private void nr_alb3_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud3_numer = nr_alb3.Text;
        }

        private void data_pod3_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud3_data = data_pod3.Text;
        }


        private void student4_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud4_kto = student4.Text;
        }

        private void nr_alb4_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud4_numer = nr_alb4.Text;
        }

        private void data_pod4_TextChanged(object sender, TextChangedEventArgs e)
        {
            stud4_data = data_pod4.Text;
        }

        private void tytul_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_tytul = tytul.Text;
        }

        private void wersja_ang_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_wersja_ang = wersja_ang.Text;
        }

        private void dane_wej_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_dane = dane_wej.Text;
        }

        private void zakres_pracy_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_zakres_pracy = zakres_pracy.Text;
        }

        private void termin_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_termin = termin.Text;
        }

        private void promotor_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_promotor = promotor.Text;
        }

        private void j_organ_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_j_organ = j_organ.Text;
        }

        private void podpis_dyr_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_podpis_dyr = podpis_dyr.Text;
        }

        private void data_pod_dziekan_TextChanged(object sender, TextChangedEventArgs e)
        {
            safe_data_pod_dziekan = data_pod_dziekan.Text;
        }
    }

}


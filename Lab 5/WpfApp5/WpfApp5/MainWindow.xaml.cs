using System;
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
using System.IO;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace WpfApp5
{

    public partial class MainWindow : Window
    {
        private Algorithm myclass = new Algorithm(); // instancja klasy Algorithm
        public int Length { get; } // potrzebna długość
        string Text; // zmienna przechowująca sekwencje
        List<string> Patterns = new List<string>(); // lista przechowująca wzorce

        public MainWindow()
        {
            InitializeComponent();
        }


        private void sekwencja_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog(); // otwiera okno dialogowe

            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true) // do zmiennej i do richtextboxa dodaje sekwencje
            {
                string filename = dlg.FileName;

                Text = File.ReadAllText(filename);
                rich.Document.Blocks.Add(new Paragraph(new Run(Text)));
            }
        }


        private void wzorce_Click(object sender, RoutedEventArgs e)
        {
            Patterns = Algorithm.Patterns_create(Text); // metoda z klasy Algorithm - zwraca listę z wzorcami
            for (int i = 0; i < Patterns.Count; i++)
            {
                wybierz.Items.Add(Text.Substring(i, 4)); // dodaje do comboboxa każdy wzorzec
            }


            for (int j = 0; j < Patterns.Count; j++)
            {
                // używana metoda z klasy Algorithm - zwraca liczbę wystąpień wzorca
                result.Text += Patterns[j] + " - " + myclass.PatternCount(Text, Patterns[j]) + "\n"; // wypisanie w textboxie wynikow
            }
        }


        private void wybierz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TextRange textRange = new TextRange(rich.Document.ContentStart, rich.Document.ContentEnd);

            textRange.ClearAllProperties(); // wyczyść poprzednie zaznaczenie

            string textBoxText = textRange.Text; // zmienna z textem z richboxtextu

            string searchText = (string)wybierz.SelectedValue; // zmienna z zaznaczonym wzorcem


            Regex regex = new Regex(searchText); // łapie wyrazy nawet w środku jakiegoś dłuższego słowa
            int count_MatchFound = Regex.Matches(textBoxText, regex.ToString()).Count;

            for (TextPointer startPointer = rich.Document.ContentStart;
                        startPointer.CompareTo(rich.Document.ContentEnd) <= 0;
                            startPointer = startPointer.GetNextContextPosition(LogicalDirection.Forward))
            {

                if (startPointer.CompareTo(rich.Document.ContentEnd) == 0) // sprawdza jeśli jest koniec tekstu
                {
                    break;
                }

                string parsedString = startPointer.GetTextInRun(LogicalDirection.Forward); // przyległe stringi

                int indexOfParseString = parsedString.IndexOf(searchText); // sprawdza czy szukany string jest obecny

                if (indexOfParseString >= 0) // istnieje
                {
                    startPointer = startPointer.GetPositionAtOffset(indexOfParseString); // ustawia pointer na index matchujący
                    if (startPointer != null)
                    {
                        TextPointer nextPointer = startPointer.GetPositionAtOffset(searchText.Length); // następny pointer -> długość szukanego stringa
                        TextRange searchedTextRange = new TextRange(startPointer, nextPointer); // tworzy TextRange
                        searchedTextRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.LightPink)); // Kolor zaznaczenia
                    }
                }
            }

        }



    }
}


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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Notatnilk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ZapiszJako_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisu = new SaveFileDialog();
            oknoZapisu.Filter = "PlainText | *.txt";
            oknoZapisu.Title = "Zapisz jako";
            if (oknoZapisu.ShowDialog() == true)
            {
                //zapisywanie do pliku
                File.WriteAllText(oknoZapisu.FileName, tekst.Text);
                //TODO nazwa pliku jako nazwa okna
            }
        }

        private void Otwórz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oknoOtwierania = new OpenFileDialog();
            oknoOtwierania.Filter = "PlainText | *.txt";
            oknoOtwierania.Title = "Otwieranie pliku";
            if(oknoOtwierania.ShowDialog() == true)
            {
                tekst.Text = File.ReadAllText(oknoOtwierania.FileName);
            }
        }

        private void Nowy_Click(object sender, RoutedEventArgs e)
        {
            //sprawdź czy coś jest zapisane w textbox
            //jeżeli tak to zapytac czy to wczesniej zapisac
            if(string.IsNullOrEmpty(tekst.Text))
            {
                tekst.Clear();
            }
            else
            {
                MessageBoxResult czyZapisac = MessageBox.Show("Masz niezapisany text, czy chciałbyś zapisać", "Wynik", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (czyZapisac == MessageBoxResult.Yes)
                {
                    SaveFileDialog a = new SaveFileDialog();
                    a.Filter = "PlainText | *.txt";
                    a.Title = "Zapisz jako";
                    if (a.ShowDialog() == true)
                    {
                        //zapisywanie do pliku
                        File.WriteAllText(a.FileName, tekst.Text);
                        //TODO nazwa pliku jako nazwa okna
                    }
                }
                else
                {
                    tekst.Clear();
                }
            }
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            //jeżeli nie zapisano to to samo co w zapisz jako
            //jeżeli plik jest już zapisany to tylko zapisujemy bez okna dialogowego
        }

        private void AutorModalne_Click(object sender, RoutedEventArgs e)
        {
            Window okno = new Window();
            okno.ShowDialog();
        }

        private void AutorNiemodalne_Click(object sender, RoutedEventArgs e)
        {
            Window okno = new Window();
            okno.Show();
        }

        private void Informacje_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Testowanie operacji na plikach oraz menu aplikacji","Informacje o programie", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

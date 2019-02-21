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
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;


namespace WpfobservableCollectionsAndConverters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Radnik> listaRadnika = new ObservableCollection<Radnik>();

        private List<string> listaPozicija = new List<string> { "Direktor", "Menadzer", "Programer", "Radnik" };

        private int Id = 5;

        private PozicijaConverter konv1 = null; 

        private void PrikaziRadnike()
        {
            ListBox1.Items.Clear();
            foreach (Radnik r in listaRadnika)
            {
                ListBox1.Items.Add(r);
            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Radnik r1 = new Radnik
            {
                RadnikId = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Pozicija = 1,
                Pol = 0
            };
            Radnik r2 = new Radnik
            {
                RadnikId = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                Pozicija = 2,
                Pol = 0
            };
            Radnik r3 = new Radnik
            {
                RadnikId = 3,
                Ime = "Jovana",
                Prezime = "Jovanovic",
                Pozicija = 2,
                Pol = 1
            };
            Radnik r4 = new Radnik
            {
                RadnikId = 4,
                Ime = "Ivana",
                Prezime = "Ivanovic",
                Pozicija = 3,
                Pol = 1
            };
            Radnik r5 = new Radnik
            {
                RadnikId = 5,
                Ime = "Marko",
                Prezime = "Markovic",
                Pozicija = 4,
                Pol = 0
            };
            listaRadnika.Add(r1);
            listaRadnika.Add(r2);
            listaRadnika.Add(r3);
            listaRadnika.Add(r4);
            listaRadnika.Add(r5);

            ListBox1.ItemsSource = listaRadnika;

            ComboBox1.ItemsSource = listaPozicija;

            konv1 = (PozicijaConverter)Resources["pozicijaConverter1"];
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxIme.Text))
            {
                MessageBox.Show("Unesite ime");
                TextBoxIme.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextBoxPrezime.Text))
            {
                MessageBox.Show("Unesite prezime");
                TextBoxPrezime.Focus();
                return false;
            }

            if (ComboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberi poziciju");
                return false;
            }

            if (RadioButtonMuski.IsChecked == false && RadioButtonZenski.IsChecked == false)
            {
                MessageBox.Show("Odaberi pol");
                return false;
            }

            return true;
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                Id++;

                Radnik r = new Radnik
                {
                    RadnikId = Id,
                    Ime = TextBoxIme.Text,
                    Prezime = TextBoxPrezime.Text,
                    Pozicija = (int)konv1.ConvertBack(ComboBox1.SelectedItem, typeof(int), null, null),

                };

                r.Pol = RadioButtonMuski.IsChecked == true ? 0 : 1;


                listaRadnika.Add(r);
                ListBox1.SelectedIndex = listaRadnika.IndexOf(r);
                ListBox1.ScrollIntoView(r);
            }

        }

        private void Resetuj()
        {
            TextBoxId.Clear();
            TextBoxIme.Clear();
            TextBoxPrezime.Clear();
            ComboBox1.SelectedIndex = -1;
            RadioButtonMuski.IsChecked = false;
            RadioButtonZenski.IsChecked = false;
            ListBox1.SelectedIndex = -1;
        }

        private void ButtonResetuj_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            int idneks = ListBox1.SelectedIndex;
        }

        private void ButtonPromeni_Click(object sender, RoutedEventArgs e)
        {
            int indeks = ListBox1.SelectedIndex;

            if (indeks > -1)
            {
                if (Validacija())
                {
                    Radnik r = listaRadnika[indeks];
                    r.Ime = TextBoxIme.Text;
                    r.Prezime = TextBoxPrezime.Text;
                    r.Pozicija = (int)konv1.ConvertBack(ComboBox1.SelectedItem, typeof(int), null, null);

                    r.Pol = RadioButtonMuski.IsChecked == true ? 0 : 1;

                    ListBox1.ItemsSource = null;
                    ListBox1.ItemsSource = listaRadnika;
                    ListBox1.SelectedIndex = indeks;
                }


            }
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex > -1)
            {
                Radnik selRadnik = (Radnik)ListBox1.SelectedItem;
                TextBoxId.Text = selRadnik.RadnikId.ToString();
                TextBoxIme.Text = selRadnik.Ime;
                TextBoxPrezime.Text = selRadnik.Prezime;
            }
        }
    }
}


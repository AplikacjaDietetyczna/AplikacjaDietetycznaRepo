using AplikacjaDietetyczna.Klasy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlPropozycja.xaml
    /// </summary>
    public partial class UserControlPropozycja : UserControl
    {
        string IDUzytkownika = FunkcjeGlobalne.ID;
        public UserControlPropozycja()
        {
            InitializeComponent();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControls.UserControlDodaj();
            GridMain.Children.Add(add);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NumberAndLettersValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z0-9 ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            if (KalorieText.Text == "" ||
            BialkaText.Text == "" ||
            TluszczeText.Text == "" ||
            WeglowodanyText.Text == "" ||
            SposobPodaniaText.Text == "" ||
            NazwaPosilkuText.Text == "")
            {
                MessageBox.Show("Prosze wypełnić wszystkie pola", "Dodawanie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    AzureDB.openConnection();
                    AzureDB.sql = "INSERT INTO Produkty (Kalorie,Bialka,Tluszcze,Weglowodany,Podanie,NazwaProduktu,Zatwierdzone,ID_User) VALUES (" + KalorieText.Text + "," + BialkaText.Text + "," + TluszczeText.Text + "," + WeglowodanyText.Text + ",'" + SposobPodaniaText.Text + "','" + NazwaPosilkuText.Text + "',0," + IDUzytkownika + ");";
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
                    AzureDB.closeConnection();
                    MessageBox.Show("Produkt został pozytywnie dodany do twojej listy", "Dodawanie", MessageBoxButton.OK, MessageBoxImage.Information);
                    KalorieText.Text = "";
                    BialkaText.Text = "";
                    TluszczeText.Text = "";
                    WeglowodanyText.Text = "";
                    SposobPodaniaText.Text = "";
                    NazwaPosilkuText.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy dodawaniu"
                                      + Environment.NewLine + "opis: " + ex.Message.ToString(), "Dodawanie"
                                      , MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

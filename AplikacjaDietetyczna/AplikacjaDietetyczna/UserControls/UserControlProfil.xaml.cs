using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
using AplikacjaDietetyczna.Klasy;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;


namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlPodsumowanie.xaml
    /// </summary>
    public partial class UserControlProfil : UserControl
    {
        public UserControlProfil()
        {
            InitializeComponent();

            //Pobranie nazwy użytkownika w celu użycia jej w zapytaniu
            string NazwaUzytkownika = FunkcjeGlobalne.Login;

            //Połączenie z bazą i pobranie danych z zapytania
            AzureDB.openConnection();
            AzureDB.sql = "SELECT Login, Email, Plec, Wiek, Wzrost,Data, Waga FROM Users INNER JOIN Waga ON Users.ID_User=Waga.ID_User WHERE Users.Login='" + NazwaUzytkownika + "' ORDER BY Data desc";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            //Tworzenie tabeli tymczasowej z pobranymi danymi i zapełnienie jej tymi danymi
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);

            //Wyświetlanie danych
            if (AzureDB.dt.Rows.Count > 0)
            {
                UzytkownikLogin.Text = AzureDB.dt.Rows[0]["Login"].ToString();
                UzytkownikPlec.Text = AzureDB.dt.Rows[0]["Plec"].ToString();
                UzytkownikWiek.Text = AzureDB.dt.Rows[0]["Wiek"].ToString();
                UzytkownikWzrost.Text = AzureDB.dt.Rows[0]["Wzrost"].ToString();
                UzytkownikWaga.Text = AzureDB.dt.Rows[0]["Waga"].ToString();
                UzytkownikEmail.Text = AzureDB.dt.Rows[0]["Email"].ToString();
            }
            DataPierwszegoWazenia();
            DataOstatniegoWazenia();

            //Zamknięcie połączenia z bazą
            AzureDB.closeConnection();
        }

        private void DataPierwszegoWazenia()
        {
            //Pobranie nazwy użytkownika w celu użycia jej w zapytaniu
            string NazwaUzytkownika = FunkcjeGlobalne.Login;
            int DataTeraz = FunkcjeGlobalne.CurrentDate;

            //Połączenie z bazą i pobranie danych z zapytania
            AzureDB.openConnection();
            AzureDB.sql = "SELECT TOP 1 Data AS 'DataRejestracji' FROM Users INNER JOIN Waga ON Users.ID_User=Waga.ID_User WHERE Users.Login='" + NazwaUzytkownika + "' ORDER BY DataRejestracji ASC";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            //Tworzenie tabeli tymczasowej z pobranymi danymi i zapełnienie jej tymi danymi
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);

            if (AzureDB.dt.Rows.Count > 0)
            {
                DateTime wartosc = Convert.ToDateTime(AzureDB.dt.Rows[0]["DataRejestracji"]);
                UzytkownikDataRejestracji.Text = AzureDB.dt.Rows[0]["DataRejestracji"].ToString();
                UzytkownikIleJestes.Text = DateKlasa.GetCalendarDate(wartosc).ToString();
                
                //DateKlasa.GetCalendarDate();

            }

            AzureDB.closeConnection();
        }
        
        private void DataOstatniegoWazenia()
        {
            AzureDB.openConnection();
            AzureDB.sql = "SELECT TOP 1 Data AS 'DataOstWaz' FROM Waga WHERE ID_User='" + FunkcjeGlobalne.ID + "' ORDER BY DataOstWaz DESC";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            //Tworzenie tabeli tymczasowej z pobranymi danymi i zapełnienie jej tymi danymi
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);

            if (AzureDB.dt.Rows.Count > 0)
            {
                UzytkownikDataWazenia.Text = AzureDB.dt.Rows[0]["DataOstWaz"].ToString();
            }
            AzureDB.closeConnection();
        }

        private void Click_ZmianaEmail(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlZmianaEmail();
            GridMain.Children.Add(add);
        }

        private void Click_ZmianaHaslo(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlZmianaHasla();
            GridMain.Children.Add(add);
        }
        private void Click_ZmianaWzrost(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlZmianaWzrostu();
            GridMain.Children.Add(add);
        }

        private void Click_ZmianaWaga(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlWaga();
            GridMain.Children.Add(add);
        }


    }
}

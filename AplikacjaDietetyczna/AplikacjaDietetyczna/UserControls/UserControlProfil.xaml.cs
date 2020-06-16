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
            AzureDB.sql = "SELECT Login, Plec, Wiek, Wzrost, Waga, Data FROM Users INNER JOIN Waga ON Users.ID_User=Waga.ID_User WHERE Users.Login='" + NazwaUzytkownika + "'";
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
                UzytkownikDataWazenia.Text = AzureDB.dt.Rows[0]["Data"].ToString();
            }
            //Zamknięcie połączenia z bazą
            AzureDB.closeConnection();
        }

        private void Click_ZmianaEmail(object sender, RoutedEventArgs e)
        {
            //UserControl add = new UserControlWaga();
            //GridMain.Children.Add(add);
        }

        private void Click_ZmianaHaslo(object sender, RoutedEventArgs e)
        {
            //UserControl add = new UserControlWaga();
            //GridMain.Children.Add(add);
        }
        private void Click_ZmianaWzrost(object sender, RoutedEventArgs e)
        {
            //UserControl add = new UserControlWaga();
            //GridMain.Children.Add(add);
        }

        private void Click_ZmianaWaga(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlWaga();
            GridMain.Children.Add(add);
        }


    }
}

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
using System.Data;
using System.Data.SqlClient;
using AplikacjaDietetyczna.Klasy;
using AplikacjaDietetyczna;
namespace AplikacjaDietetyczna
{
    /// <summary>
    /// Interaction logic for Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        public Rejestracja()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
        }
        private void Rejestracja_Click(object sender, RoutedEventArgs e)
        {
            AzureDB.openConnection();
            //AzureDB.sql = "INSERT INTO Users (ID_User, Login, Password, Email) VALUES (5, '"+TextBoxUser.Text+"', '"+TextBoxPassword.Password + "', '"+EMail.Text+ "')";
            AzureDB.sql = "INSERT INTO Users (Login, Password, Email, Wiek, Wzrost, Plec) VALUES ('Sasek', 'haslo', 'gmail@gmail.com', 18, 180, 'M')";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.closeConnection();


        }
        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
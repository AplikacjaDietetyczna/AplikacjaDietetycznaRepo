using AplikacjaDietetyczna.Klasy;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserControlZmianaEmail.xaml
    /// </summary>
    public partial class UserControlZmianaEmail : UserControl
    {
        public UserControlZmianaEmail()
        {
            InitializeComponent();
        }

       

        private void Click_ZmianaEmail(object sender, RoutedEventArgs e)
        {
            //sprawdzenie czy email zgadza się z regexem
            string email = TextBoxEmail.Text;
            Regex regexEmail = new Regex(WyrażeniaRegularne.EmailRegex());
            Match sprawdzenieEmail = regexEmail.Match(email);

            if (sprawdzenieEmail.Success )//jeżeli sprawdzenie emaila przebiegnie pomyślnie
            {
                //aktualizacja email
                AzureDB.sql = "UPDATE Users SET Email='" + TextBoxEmail.Text + "' WHERE ID_User='" + FunkcjeGlobalne.ID + "'";
                AzureDB.openConnection();
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.cmd.ExecuteNonQuery();
                AzureDB.closeConnection();
                //testowy messageBox jeśli wszystko się uda
                MessageBoxResult rezultat = MessageBox.Show("Zaktualizowano Email.", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult rezultat = MessageBox.Show("Podano niepoprawny adres email.", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Click_ZmianaEmailWroc(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlProfil();
            GridMain.Children.Add(add);
        }
    }
}

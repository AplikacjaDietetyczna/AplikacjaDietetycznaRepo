using AplikacjaDietetyczna.Klasy;
using System;
using System.Collections.Generic;
using System.Data;
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
            AzureDB.openConnection();
            AzureDB.sql = "UPDATE Users SET Email='"+TextBoxEmail.Text+"' WHERE ID_User='"+FunkcjeGlobalne.ID+"'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.cmd.ExecuteNonQuery();
            AzureDB.closeConnection();
            MessageBoxResult rezultat = MessageBox.Show("Dodano nowy email dla usera: " + FunkcjeGlobalne.ID + " o wartości: " + TextBoxEmail.Text + " .", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Click_ZmianaEmailWroc(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlProfil();
            GridMain.Children.Add(add);
        }
    }
}

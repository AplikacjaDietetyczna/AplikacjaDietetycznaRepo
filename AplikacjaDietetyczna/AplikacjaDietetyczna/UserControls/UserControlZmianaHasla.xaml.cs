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
    /// Interaction logic for UserControlZmianaHasla.xaml
    /// </summary>
    public partial class UserControlZmianaHasla : UserControl
    {
        public UserControlZmianaHasla()
        {
            InitializeComponent();
        }

        private void Click_ZmianaHasla(object sender, RoutedEventArgs e)
        {
            AzureDB.openConnection();
            AzureDB.sql = "UPDATE Users SET Email='" + TextBoxHaslo.Text + "' WHERE ID_User='" + FunkcjeGlobalne.ID + "'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.cmd.ExecuteNonQuery();
            AzureDB.closeConnection();
            MessageBoxResult rezultat = MessageBox.Show("Dodano nowy email dla usera: " + FunkcjeGlobalne.ID + " o wartości: " + TextBoxHaslo.Text + " .", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Click_ZmianaHaslaWroc(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlProfil();
            GridMain.Children.Add(add);
        }
    }
}

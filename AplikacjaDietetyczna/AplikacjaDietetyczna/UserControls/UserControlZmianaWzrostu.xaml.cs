using AplikacjaDietetyczna.Klasy;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for UserControlZmianaWzrostu.xaml
    /// </summary>
    public partial class UserControlZmianaWzrostu : UserControl
    {
        public UserControlZmianaWzrostu()
        {
            InitializeComponent();
        }

        private void Click_ZmianaWzrostu(object sender, RoutedEventArgs e)
        {
            //sprawdzenie czy podany wzrost zgadza się z regexem
            string wzrost = TextBoxWzrost.Text;
            Regex regexWzrost = new Regex(WyrażeniaRegularne.HeightRegex());
            Match sprawdzenieWzrost = regexWzrost.Match(wzrost);
            if (sprawdzenieWzrost.Success) {
                AzureDB.openConnection();
                AzureDB.sql = "UPDATE Users SET Wzrost='" + TextBoxWzrost.Text + "' WHERE ID_User='" + FunkcjeGlobalne.ID + "'";
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.cmd.ExecuteNonQuery();
                AzureDB.closeConnection();
                MessageBoxResult rezultat = MessageBox.Show("Uaktualniono wzrost.", "Wzrost", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult rezultat = MessageBox.Show("Podano błędny wzrost.", "Wzrost", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Click_Wroc(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlProfil();
            GridMain.Children.Add(add);
        }
    }
}

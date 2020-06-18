using AplikacjaDietetyczna.Klasy;
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

namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy UserControlWaga.xaml
    /// </summary>
    public partial class UserControlWaga : UserControl
    {
        public UserControlWaga()
        {
            InitializeComponent();
        }

        private void Click_Wroc(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlProfil();
            GridMain.Children.Add(add);
        }

        private void Click_ZmianaWaga(object sender, RoutedEventArgs e)
        {
            DateTime aktualnaData = DateTime.Now;
            string sqlFormattedDate=aktualnaData.ToString("yyyy-MM-dd HH:mm:ss.fff");
            //int waga = Convert.ToInt32(Waga.Text);
            AzureDB.openConnection();
            //AzureDB.sql="SELECT"
            //AzureDB.openConnection();
            AzureDB.sql = "INSERT INTO Waga (ID_User, Waga, Data) VALUES ('" + FunkcjeGlobalne.ID + "','" + TextBoxWaga.Text + "','" + aktualnaData + "')";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.cmd.ExecuteNonQuery();
            AzureDB.closeConnection();
            //Testowe
            MessageBoxResult rezultat = MessageBox.Show("Dodano nową wagę dla usera: " + FunkcjeGlobalne.ID + " w dacie: " + aktualnaData + " o wartości: " + TextBoxWaga.Text + " .", "Waga", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

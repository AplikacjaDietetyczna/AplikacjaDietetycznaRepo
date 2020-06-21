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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

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
            HistoriaWagi();
        }

        private void Click_Wroc(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlProfil();
            GridMain.Children.Add(add);
        }

        private void Click_ZmianaWaga(object sender, RoutedEventArgs e)
        {
            string waga = TextBoxWaga.Text;
            Regex regexWaga = new Regex(WyrażeniaRegularne.WeightRegex());
            Match sprawdzenieWagi = regexWaga.Match(waga);
            if (sprawdzenieWagi.Success)
            {
                DateTime aktualnaData = DateTime.Now;
                string sqlFormattedDate = aktualnaData.ToString("yyyy-MM-dd HH:mm:ss.fff");
                AzureDB.openConnection();
                AzureDB.sql = "INSERT INTO Waga (ID_User, Waga, Data) VALUES ('" + FunkcjeGlobalne.ID + "','" + TextBoxWaga.Text + "','" + aktualnaData + "')";
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.cmd.ExecuteNonQuery();
                AzureDB.closeConnection();
                MessageBoxResult rezultat = MessageBox.Show("Uaktualniono wagę.", "Waga", MessageBoxButton.OK, MessageBoxImage.Information);
                HistoriaWagi();
            }
            else
            {
                MessageBoxResult rezultat = MessageBox.Show("Podano niepoprawną wagę.", "Waga", MessageBoxButton.OK, MessageBoxImage.Information);
                HistoriaWagi();
            }
        }

        private void HistoriaWagi()
        {
            AzureDB.openConnection();
            //AzureDB.con.InfoMessage += new SqlInfoMessageEventHandler(conn_InfoMessage);
            //AzureDB.con.FireInfoMessageEventOnUserErrors = true;
            AzureDB.sql = "Select Waga, Data FROM Waga WHERE ID_User='"+FunkcjeGlobalne.ID+"'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            HistoriaWagDataGrid.ItemsSource = AzureDB.dt.DefaultView;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using AplikacjaDietetyczna.Klasy;
using Microsoft.SqlServer;

namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSQL.xaml
    /// </summary>
    public partial class UserControlSQL : UserControl
    {
        private void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            txtMessages.Text = "\n" + e.Message;
        }
        private void Start()
        {
            AzureDB.openConnection();
            AzureDB.con.InfoMessage += new SqlInfoMessageEventHandler(conn_InfoMessage);
            AzureDB.con.FireInfoMessageEventOnUserErrors = true;
            AzureDB.sql = Select.Text;
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            SelectDataGrid.ItemsSource = AzureDB.dt.DefaultView;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Start();
        }

        public UserControlSQL()
        {
            InitializeComponent();
        }
       
        private void Click_sql(object sender, RoutedEventArgs e)
        {
            try
            {
                AzureDB.sql = Select.Text;
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                AzureDB.dt = new DataTable();
                AzureDB.da.Fill(AzureDB.dt);
                SelectDataGrid.ItemsSource = AzureDB.dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: "+ex.Message, "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ZapisaneSQL_closing(object sender, EventArgs e)
        {
            Select.Text = ((ComboBoxItem)ZapisaneSQL.SelectedItem).Tag.ToString();
        }
    }
}

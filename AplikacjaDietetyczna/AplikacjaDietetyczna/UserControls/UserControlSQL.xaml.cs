using System;
using System.Collections.Generic;
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

namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSQL.xaml
    /// </summary>
    public partial class UserControlSQL : UserControl
    {
        public UserControlSQL()
        {
            InitializeComponent();
            AzureDB.openConnection();
            AzureDB.sql = Select.Text;
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            SelectDataGrid.ItemsSource = AzureDB.dt.DefaultView;
            AzureDB.closeConnection();

        }
       
        private void Click_sql(object sender, RoutedEventArgs e)
        {
            try
            {
                AzureDB.openConnection();
                AzureDB.sql = Select.Text;
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                AzureDB.dt = new DataTable();
                AzureDB.da.Fill(AzureDB.dt);
                SelectDataGrid.ItemsSource = AzureDB.dt.DefaultView;
                AzureDB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: "+ex.Message, "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

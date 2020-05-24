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
        private void WypelnijTabele()
        {
            AzureDB.openConnection();
            AzureDB.sql = Select.Text;
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.cmd.ExecuteNonQuery();
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            SelectDataGrid.ItemsSource = AzureDB.dt.DefaultView;
            AzureDB.closeConnection();
        }
        public UserControlSQL()
        {
            InitializeComponent();
            WypelnijTabele();

        }
        private void Zatwierdz(Object sender, KeyEventArgs e)//wykonywanie query za pomoca entera
        {
            /*
            if (e.Key == Key.Enter)
            {
                try
                {
                    WypelnijTabele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Niepoprawne Query Error:" + ex, "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            */
        }
        private void Click_sql(object sender, RoutedEventArgs e)
        {
            try
            {
                WypelnijTabele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Niepoprawne Query Error:"+ex, "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

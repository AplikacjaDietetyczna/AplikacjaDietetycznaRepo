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
using System.Net.Mail;

namespace AplikacjaDietetyczna
{
    /// <summary>
    /// Interaction logic for SqlQuery.xaml
    /// </summary>
    public partial class SqlQuery : Window
    {
        public SqlQuery()
        {
            InitializeComponent();
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); }; //Wyłącza program
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void Execute_click(object sender, RoutedEventArgs e)
        {
            try
            {

                AzureDB.openConnection();
                AzureDB.sql = TextBoxSQL.Text;
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
                AzureDB.closeConnection();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex, "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

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

                if (Select.Text != "SELECT ID_Produktu, Users.ID_User,NazwaProduktu, Kalorie, Bialka, Tluszcze, Weglowodany, Podanie, Zatwierdzone FROM Produkty INNER JOIN Users ON Produkty.ID_User = Users.ID_User WHERE Zatwierdzone=0")
                {
                    DoZatwierdzenia.Opacity = 0;
                    DoZatwierdzenia.IsEnabled = false;
                    DoZatwierdzeniaTekst.Opacity = 0;
                    DoZatwierdzeniaTekst.IsEnabled = false;
                    Zatwierdz.Opacity = 0;
                    Zatwierdz.IsEnabled = false;
                }

                else
                {
                    DoZatwierdzenia.Opacity = 1;
                    DoZatwierdzenia.IsEnabled = true;
                    DoZatwierdzeniaTekst.Opacity = 1;
                    DoZatwierdzeniaTekst.IsEnabled = true;
                    Zatwierdz.Opacity = 1;
                    Zatwierdz.IsEnabled = true;
                }

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

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            int ID_Produktu = Convert.ToInt32(DoZatwierdzenia.Text);

            try
            {
               
                AzureDB.openConnection();
                AzureDB.sql = "UPDATE Produkty SET Zatwierdzone = 1 WHERE ID_Produktu = '"+ID_Produktu+"'";
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.cmd.ExecuteNonQuery(); 
                AzureDB.closeConnection();
                MessageBox.Show("Dodano produkt " + ID_Produktu + " do głównej bazy produktów", "aktualizacja", MessageBoxButton.OK, MessageBoxImage.Information);
                Start();
            }
            catch (Exception ex)//jesli baza nie dziala
            {
                MessageBox.Show("Błąd przy aktualizacji"
                   + Environment.NewLine + "opis: " + ex.Message.ToString(), "aktualizacja"
                   , MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}

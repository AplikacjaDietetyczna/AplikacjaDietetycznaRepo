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

namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlPodsumowanie.xaml
    /// </summary>
    public partial class UserControlPodsumowanie : UserControl
    {
        public UserControlPodsumowanie()
        {
            InitializeComponent();

          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string sqlFormattedDate = DateKlasa.GetDate(Convert.ToInt32(FunkcjeGlobalne.Data)).ToString("yyyy-MM-dd");

            String message = "Nie udało połączyć się z bazą danych"; 

            try
            {
                AzureDB.openConnection();
                AzureDB.sql = "SELECT (Ilosc * Kalorie) AS KalorieRazem FROM Users INNER JOIN Posilki ON Posilki.ID_User = Users.ID_User INNER JOIN PosilkiProdukty ON Posilki.ID_Posilku = PosilkiProdukty.ID_Posilku INNER JOIN Produkty ON Produkty.ID_Produktu = PosilkiProdukty.ID_Produktu WHERE Data = '"+sqlFormattedDate+"'";
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                AzureDB.dt = new DataTable();
                AzureDB.da.Fill(AzureDB.dt);
                if (AzureDB.dt.Rows.Count > 0)
                {
                    DzienneKalorie.Text = AzureDB.dt.Rows[0]["KalorieRazem"].ToString();
                }
                AzureDB.closeConnection();
            }
            catch (Exception ex)
            {

                message = ex.Message.ToString();
            }

            DzienneKalorie.Text += "/"+Zapotrzebowanie.GetKalorie()+" kcal";



        }



    }
}

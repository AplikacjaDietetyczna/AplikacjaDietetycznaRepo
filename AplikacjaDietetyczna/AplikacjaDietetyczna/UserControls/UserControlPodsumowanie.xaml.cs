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
            double Kalorie = 0;
            try
            {
                AzureDB.openConnection();
                AzureDB.sql = "SELECT SUM((Ilosc * Kalorie)) AS KalorieRazem, SUM((Ilosc * Bialka)) AS BialkaRazem, SUM((Ilosc * Tluszcze)) AS TluszczeRazem, SUM((Ilosc * Weglowodany)) AS WeglowodanyRazem  FROM Users   INNER JOIN Posilki ON Posilki.ID_User = Users.ID_User INNER JOIN PosilkiProdukty ON Posilki.ID_Posilku = PosilkiProdukty.ID_Posilku INNER JOIN Produkty ON Produkty.ID_Produktu = PosilkiProdukty.ID_Produktu WHERE Data = '" + sqlFormattedDate+"' AND Users.ID_User = '"+FunkcjeGlobalne.ID+"'";
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                AzureDB.dt = new DataTable();
                AzureDB.da.Fill(AzureDB.dt);
                if (AzureDB.dt.Rows.Count > 0)
                {
                    DzienneKalorie.Text = AzureDB.dt.Rows[0]["KalorieRazem"].ToString();
                    Kalorie = Convert.ToDouble(AzureDB.dt.Rows[0]["KalorieRazem"].ToString());
                    DzienneBialka.Text = AzureDB.dt.Rows[0]["BialkaRazem"].ToString();
                  //  Bialka = Convert.ToDouble(AzureDB.dt.Rows[0]["BialkaRazem"].ToString());
                    DzienneTluszcze.Text = AzureDB.dt.Rows[0]["TluszczeRazem"].ToString();
                  //  Tluszcze = Convert.ToDouble(AzureDB.dt.Rows[0]["TluszczeRazem"].ToString());
                    DzienneWeglowodany.Text = AzureDB.dt.Rows[0]["WeglowodanyRazem"].ToString();
                    //Weglowodany = Convert.ToDouble(AzureDB.dt.Rows[0]["WeglowodanyRazem"].ToString());
                }
                AzureDB.closeConnection();
            }
            catch (Exception ex)
            {

                message = ex.Message.ToString();
                DzienneKalorie.Text = "0";
            }

            DzienneKalorie.Text += "/"+Zapotrzebowanie.GetKalorie()+" kcal";
            DzienneBialka.Text += "/" + Zapotrzebowanie.GetBialka() + " g";
            DzienneTluszcze.Text += "/" + Zapotrzebowanie.GetTluszcze() + " g";
            DzienneWeglowodany.Text += "/" + Zapotrzebowanie.GetWeglowodany() + " g";

            if (Kalorie >= Zapotrzebowanie.GetKalorie())
            {
                DzienneZapotrzebowanie.Text = "Tak";
            }
            else DzienneZapotrzebowanie.Text = "Nie";


        }



    }
}

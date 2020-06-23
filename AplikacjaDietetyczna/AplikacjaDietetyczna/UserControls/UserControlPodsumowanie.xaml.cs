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

        private void Podsumowanie(int IloscDni)
        {
            
            int SpelnioneZapotrzebowanie = 0;
            int CurrentDate = Convert.ToInt32(FunkcjeGlobalne.Data);
            int DataTydzien = CurrentDate - IloscDni;
            if (IloscDni == 0)
            {
                CurrentDate = CurrentDate + 1;
            }
            double KalorieRazem = 0;
            double BialkaRazem = 0;
            double TluszczeRazem = 0;
            double WeglowodanyRazem = 0;
            double Weglowodany = 0;
            double Tluszcze = 0;
            double Bialka = 0;
            while (DataTydzien != CurrentDate)
            {



                string sqlFormattedDate = DateKlasa.GetDate(Convert.ToInt32(DataTydzien)).ToString("yyyy-MM-dd");
                String message = "Nie udało połączyć się z bazą danych";
                double Kalorie = 0;
                try
                {
                    AzureDB.openConnection();
                    AzureDB.sql = "SELECT SUM((Ilosc * Kalorie)) AS KalorieRazem, SUM((Ilosc * Bialka)) AS BialkaRazem, SUM((Ilosc * Tluszcze)) AS TluszczeRazem, SUM((Ilosc * Weglowodany)) AS WeglowodanyRazem  FROM Users   INNER JOIN Posilki ON Posilki.ID_User = Users.ID_User INNER JOIN PosilkiProdukty ON Posilki.ID_Posilku = PosilkiProdukty.ID_Posilku INNER JOIN Produkty ON Produkty.ID_Produktu = PosilkiProdukty.ID_Produktu WHERE Data = '" + sqlFormattedDate + "' AND Users.ID_User = '" + FunkcjeGlobalne.ID + "'";
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                    AzureDB.dt = new DataTable();
                    AzureDB.da.Fill(AzureDB.dt);
                    if (AzureDB.dt.Rows.Count > 0)
                    {
                        DzienneKalorie.Text = AzureDB.dt.Rows[0]["KalorieRazem"].ToString();
                        Kalorie = Convert.ToDouble(AzureDB.dt.Rows[0]["KalorieRazem"].ToString());
                        Bialka = Convert.ToDouble(AzureDB.dt.Rows[0]["BialkaRazem"].ToString());
                        Tluszcze = Convert.ToDouble(AzureDB.dt.Rows[0]["TluszczeRazem"].ToString());
                        Weglowodany = Convert.ToDouble(AzureDB.dt.Rows[0]["WeglowodanyRazem"].ToString());
                    }
                    AzureDB.closeConnection();
                }
                catch (Exception ex)
                {

                    message = ex.Message.ToString();
                    DzienneKalorie.Text = "0";
                }
                KalorieRazem += Kalorie;
                BialkaRazem += Bialka;
                TluszczeRazem += Tluszcze;
                WeglowodanyRazem += Weglowodany;


             
                if (IloscDni != 0)
                {
                    DzienneKalorie.Text = KalorieRazem + "/" + Zapotrzebowanie.GetKalorie() * IloscDni + " kcal";
                    DzienneBialka.Text = BialkaRazem + "/" + Zapotrzebowanie.GetBialka() * IloscDni + " g";
                    DzienneTluszcze.Text = TluszczeRazem + "/" + Zapotrzebowanie.GetTluszcze() * IloscDni + " g";
                    DzienneWeglowodany.Text = WeglowodanyRazem + "/" + Zapotrzebowanie.GetWeglowodany() * IloscDni + " g";
                }
               
                else
                {
                    DzienneKalorie.Text = KalorieRazem + "/" + Zapotrzebowanie.GetKalorie() + " kcal";
                    DzienneBialka.Text = BialkaRazem + "/" + Zapotrzebowanie.GetBialka() + " g";
                    DzienneTluszcze.Text = TluszczeRazem + "/" + Zapotrzebowanie.GetTluszcze() + " g";
                    DzienneWeglowodany.Text = WeglowodanyRazem + "/" + Zapotrzebowanie.GetWeglowodany() + " g";
                }

                if(FunkcjeGlobalne.Tryb == "Dzienne")
                {
                    if (Kalorie >= Zapotrzebowanie.GetKalorie())
                    {
                        SpelnioneZapotrzebowanie++;
                        DzienneZapotrzebowanie.Text = "Tak";
                    }
                    else
                    {
                        DzienneZapotrzebowanie.Text = "Nie";
                    }
                }

                else if(FunkcjeGlobalne.Tryb != "Dzienne")
                {
                    DzienneZapotrzebowanie.Text = SpelnioneZapotrzebowanie + " razy";
                    if (Kalorie >= Zapotrzebowanie.GetKalorie())
                    {
                        SpelnioneZapotrzebowanie++;
                        DzienneZapotrzebowanie.Text = SpelnioneZapotrzebowanie +" razy";
                    }
                }

                Kalorie = 0;
                Bialka = 0;
                Tluszcze = 0;
                Weglowodany = 0;
                DataTydzien++;

            }

            SpelnioneZapotrzebowanie = 0;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.Tryb = "Tygodniowe";
            FunkcjeGlobalne.Data = "1";
            Podsumowanie(7);
            DataStartowa.Text = "Wybrana data:  " + DateTime.Now.ToString("dd/MM/yyyy");
            CalendarDateRange cdr = new CalendarDateRange(DateTime.Today.AddDays(1), DateTime.Today.AddMonths(24));
            Kalendarz.BlackoutDates.Add(cdr);
        }

        private void Dzienne(object sender, RoutedEventArgs e)
        {



                FunkcjeGlobalne.Tryb = "Dzienne";
                Nazwa.Text = "Dzienne";
                Podsumowanie(1);
                



        }


        private void Miesieczne(object sender, RoutedEventArgs e)
        {
                Nazwa.Text = "Miesięczne";
                FunkcjeGlobalne.Tryb = "Miesieczne";
                Podsumowanie(31);
              





        }



        private void Tygodniowe(object sender, RoutedEventArgs e)
        {
                FunkcjeGlobalne.Tryb = "Tygodniowe";
                Podsumowanie(7);
                Nazwa.Text = "Tygodniowe";
                




        }


        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(Kalendarz.SelectedDate);
            DateTime date = DateTime.Now;
            var datebez = date.Date;
            DataStartowa.Text = "Wybrana data " + Kalendarz.SelectedDate.Value.ToString("dd/MM/yyyy");

            int IloscDni = DateKlasa.GetCalendarDate(Kalendarz.SelectedDate.Value);
            FunkcjeGlobalne.Data = Convert.ToString(-IloscDni + 1);

            if (FunkcjeGlobalne.Tryb == "Tygodniowe")
            {
                Nazwa.Text = "Tygodniowe";
                Podsumowanie(7);
            }

            if (FunkcjeGlobalne.Tryb == "Dzienne")
            {
                Nazwa.Text = "Dzienne";
                Podsumowanie(1);
            }

            if (FunkcjeGlobalne.Tryb == "Miesieczne")
            {
                Nazwa.Text = "Miesieczne";
                Podsumowanie(31);
            }


        }
    }
}

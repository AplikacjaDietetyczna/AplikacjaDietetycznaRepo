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
using AplikacjaDietetyczna.Klasy;

namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy UserControlPosilki.xaml
    /// </summary>
    public partial class UserControlPosilki : UserControl
    {
        public UserControlPosilki()
        {
            InitializeComponent();
        }

      
        public DateTime GetDate(int n)
        {

            DateTime dateTime = DateTime.Now.AddDays(n);
            return dateTime;
        }

        private void Window_LoadedZapotrzebowanie(object sender, RoutedEventArgs e)
        {
            string TypPosilku = "Sniadanie";
            double SniadanieKalorieD = 0;
            SniadanieKalorie.Text = "0 kcal";
            string sqlFormattedDate = GetDate(Convert.ToInt32(FunkcjeGlobalne.Data)).ToString("yyyy-MM-dd");
            string SniadanieProdukty = "";
            string SniadanieNazwa = "";
            int SniadanieIlosc = 0;
            string SniadaniePodanie = "";
            string SniadanieBebg = "";
            TextBoxCurrentDate.Text = sqlFormattedDate;
            String message2 = "Nie udalo sie pobrac danych do dekoratora";
            try
            {
                Dekorator.Posilek sniadanie = new Dekorator.TypPosilku();
                sniadanie = new Dekorator.ProduktDekorator(sniadanie);

                AzureDB.openConnection();
                AzureDB.sql = "SELECT Nazwa, NazwaProduktu, Podanie, Ilosc, Kalorie,TypPosilku, Weglowodany, Bialka, Tluszcze FROM Users  INNER JOIN Posilki ON Posilki.ID_User = Users.ID_User INNER JOIN PosilkiProdukty ON Posilki.ID_Posilku = PosilkiProdukty.ID_Posilku INNER JOIN Produkty ON Produkty.ID_Produktu = PosilkiProdukty.ID_Produktu WHERE Users.ID_User = 20 AND Data = '" + sqlFormattedDate + "' AND TypPosilku = '" + TypPosilku + "' ";
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.rd = AzureDB.cmd.ExecuteReader();

                if (AzureDB.rd.HasRows)
                {
                    while (AzureDB.rd.Read())
                    {
                        SniadanieKalorieD += sniadanie.CalculateKalorie(Convert.ToDouble(AzureDB.rd["Kalorie"].ToString()));
                        if (SniadanieNazwa != AzureDB.rd["Nazwa"].ToString())
                        {
                            SniadanieTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                            SniadanieBebg = "";
                        }

                        SniadanieNazwa = AzureDB.rd["Nazwa"].ToString();


                        SniadanieProdukty = AzureDB.rd["NazwaProduktu"].ToString();
                        SniadanieProdukty += ", ";
                        SniadanieIlosc = Convert.ToInt32(AzureDB.rd["Ilosc"].ToString());
                        SniadaniePodanie = AzureDB.rd["Podanie"].ToString();
                        SniadanieBebg += sniadanie.GetName(SniadanieProdukty, SniadanieIlosc, SniadaniePodanie);



                    }
                }
                AzureDB.closeConnection();


                SniadanieTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                SniadanieTekst.Text = SniadanieTekst.Text.Remove(SniadanieTekst.Text.Length - 2);
                SniadanieKalorie.Text = Convert.ToString(SniadanieKalorieD) + " kcal";




            }
            catch (Exception ex)
            {

                message2 = ex.Message.ToString();
            }






            //Zapotrzebowanie dzienne
            String message = "Nie udało się wyliczyć zapotrzebowania dziennego";
            try
            {


                //Harris-Benedict
                //Mężczyźni: 66.5 + (13.75 * waga) + (5.003 * wzrost) - (6.775 * wiek) Kobiety: 655.1 + (9.563 * waga) + (1.85 * wzrost)-(4.676 * wiek)
                double DzienneZapotrzebowanie = 0;
                if (FunkcjeGlobalne.Plec == "M")
                {
                    DzienneZapotrzebowanie = 66.5 + (13.75 * Convert.ToDouble(FunkcjeGlobalne.Waga)) + (5.003 * Convert.ToDouble(FunkcjeGlobalne.Wzrost)) - (6.775 * Convert.ToDouble(FunkcjeGlobalne.Wiek));
                }
                else
                {
                    DzienneZapotrzebowanie = 655.1 + (9.563 * Convert.ToDouble(FunkcjeGlobalne.Waga)) + (1.85 * Convert.ToDouble(FunkcjeGlobalne.Wzrost)) - (4.676 * Convert.ToDouble(FunkcjeGlobalne.Wiek));
                }
                //Do drugiego miejsca po przecinku
                double Bialka = Math.Round((Double)DzienneZapotrzebowanie * 0.15, 2);
                double Kalorie = Math.Round((Double)DzienneZapotrzebowanie, 2);
                double Tluszcze = Math.Round((Double)DzienneZapotrzebowanie * 0.30, 2);
                double Weglowodany = Math.Round((Double)DzienneZapotrzebowanie * 0.55, 2);

                TextBoxKalorie.Text = "Kalorie: Ile / " + Kalorie + " kcal";
                TextBoxBialka.Text = "Białka: Ile / " + Bialka + " g";
                TextBoxTluszcze.Text = "Tłuszcze: Ile / " + Tluszcze + " g";
                TextBoxWeglowodany.Text = "Węglowodany: Ile / " + Weglowodany + " g";

            }
            catch (Exception ex)
            {

                message = ex.Message.ToString();
            }

        }

        private void MinusDay(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.CurrentDate = Convert.ToInt32(FunkcjeGlobalne.Data);

            FunkcjeGlobalne.Data = Convert.ToString(FunkcjeGlobalne.CurrentDate - 1);
            string TypPosilku = "Sniadanie";
            double SniadanieKalorieD = 0;
            SniadanieKalorie.Text = "0 kcal";
            string sqlFormattedDate = GetDate(Convert.ToInt32(FunkcjeGlobalne.Data)).ToString("yyyy-MM-dd");
            string SniadanieProdukty = "";
            string SniadanieNazwa = "";
            int SniadanieIlosc = 0;
            string SniadaniePodanie = "";
            string SniadanieBebg = "";
            TextBoxCurrentDate.Text = sqlFormattedDate;
            String message2 = "Nie udalo sie pobrac danych do dekoratora";
            try
            {
                Dekorator.Posilek sniadanie = new Dekorator.TypPosilku();
                sniadanie = new Dekorator.ProduktDekorator(sniadanie);

                AzureDB.openConnection();
                AzureDB.sql = "SELECT Nazwa, NazwaProduktu, Podanie, Ilosc, Kalorie,TypPosilku, Weglowodany, Bialka, Tluszcze FROM Users  INNER JOIN Posilki ON Posilki.ID_User = Users.ID_User INNER JOIN PosilkiProdukty ON Posilki.ID_Posilku = PosilkiProdukty.ID_Posilku INNER JOIN Produkty ON Produkty.ID_Produktu = PosilkiProdukty.ID_Produktu WHERE Users.ID_User = 20 AND Data = '" + sqlFormattedDate + "' AND TypPosilku = '" + TypPosilku + "' ";
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.rd = AzureDB.cmd.ExecuteReader();

                if (AzureDB.rd.HasRows)
                {
                    while (AzureDB.rd.Read())
                    {
                        SniadanieKalorieD += sniadanie.CalculateKalorie(Convert.ToDouble(AzureDB.rd["Kalorie"].ToString()));
                        if (SniadanieNazwa != AzureDB.rd["Nazwa"].ToString())
                        {
                            SniadanieTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                            SniadanieBebg = "";
                        }

                        SniadanieNazwa = AzureDB.rd["Nazwa"].ToString();


                        SniadanieProdukty = AzureDB.rd["NazwaProduktu"].ToString();
                        SniadanieProdukty += ", ";
                        SniadanieIlosc = Convert.ToInt32(AzureDB.rd["Ilosc"].ToString());
                        SniadaniePodanie = AzureDB.rd["Podanie"].ToString();
                        SniadanieBebg += sniadanie.GetName(SniadanieProdukty, SniadanieIlosc, SniadaniePodanie);



                    }
                }
                AzureDB.closeConnection();


                SniadanieTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                SniadanieTekst.Text = SniadanieTekst.Text.Remove(SniadanieTekst.Text.Length - 2);
                SniadanieKalorie.Text = Convert.ToString(SniadanieKalorieD) + " kcal";






            }
            catch (Exception ex)
            {

                message2 = ex.Message.ToString();
            }






            //Zapotrzebowanie dzienne
            String message = "Nie udało się wyliczyć zapotrzebowania dziennego";
            try
            {


                //Harris-Benedict
                //Mężczyźni: 66.5 + (13.75 * waga) + (5.003 * wzrost) - (6.775 * wiek) Kobiety: 655.1 + (9.563 * waga) + (1.85 * wzrost)-(4.676 * wiek)
                double DzienneZapotrzebowanie = 0;
                if (FunkcjeGlobalne.Plec == "M")
                {
                    DzienneZapotrzebowanie = 66.5 + (13.75 * Convert.ToDouble(FunkcjeGlobalne.Waga)) + (5.003 * Convert.ToDouble(FunkcjeGlobalne.Wzrost)) - (6.775 * Convert.ToDouble(FunkcjeGlobalne.Wiek));
                }
                else
                {
                    DzienneZapotrzebowanie = 655.1 + (9.563 * Convert.ToDouble(FunkcjeGlobalne.Waga)) + (1.85 * Convert.ToDouble(FunkcjeGlobalne.Wzrost)) - (4.676 * Convert.ToDouble(FunkcjeGlobalne.Wiek));
                }
                //Do drugiego miejsca po przecinku
                double Bialka = Math.Round((Double)DzienneZapotrzebowanie * 0.15, 2);
                double Kalorie = Math.Round((Double)DzienneZapotrzebowanie, 2);
                double Tluszcze = Math.Round((Double)DzienneZapotrzebowanie * 0.30, 2);
                double Weglowodany = Math.Round((Double)DzienneZapotrzebowanie * 0.55, 2);

                TextBoxKalorie.Text = "Kalorie: Ile / " + Kalorie + " kcal";
                TextBoxBialka.Text = "Białka: Ile / " + Bialka + " g";
                TextBoxTluszcze.Text = "Tłuszcze: Ile / " + Tluszcze + " g";
                TextBoxWeglowodany.Text = "Węglowodany: Ile / " + Weglowodany + " g";

            }
            catch (Exception ex)
            {

                message = ex.Message.ToString();
            }


        }

        private void PlusDay(object sender, RoutedEventArgs e)
        {
        //    FunkcjeGlobalne.CurrentDate = Convert.ToInt32(FunkcjeGlobalne.Data);

        //    FunkcjeGlobalne.Data = Convert.ToString(FunkcjeGlobalne.CurrentDate + 1);

        //    string WeglowodanyString = "";
        //    string KalorieString = "";
        //    KalorieSniadanie.Text = "0";


        //    // Zapisanie dzisiejszej daty do zmiennej oraz przeformatowanie jej do formatu SQLowego

        //    string sqlFormattedDate = GetDate(Convert.ToInt32(FunkcjeGlobalne.Data)).ToString("yyyy-MM-dd");

        //    TextBoxCurrentDate.Text = sqlFormattedDate;
        //    String message2 = "Nie udalo sie pobrac danych do dekoratora";
        //    try
        //    {


        //        AzureDB.openConnection();
        //        AzureDB.sql = "SELECT Kalorie, Weglowodany, Bialka, Tluszcze FROM Users  INNER JOIN Posilki ON Posilki.ID_User = Users.ID_User INNER JOIN PosilkiProdukty ON Posilki.ID_Posilku = PosilkiProdukty.ID_Posilku INNER JOIN Produkty ON Produkty.ID_Produktu = PosilkiProdukty.ID_Produktu WHERE Users.ID_User = 20 AND Data = '" + sqlFormattedDate + "'";
        //        AzureDB.cmd.CommandText = AzureDB.sql;
        //        AzureDB.rd = AzureDB.cmd.ExecuteReader();

        //        if (AzureDB.rd.Read())
        //        {
        //            //UserID = AzureDB.rd["ID_User"].ToString();
        //            //Console.WriteLine(UserID); //Do testowania
        //            WeglowodanyString = AzureDB.rd["Weglowodany"].ToString();
        //            KalorieSniadanie.Text = AzureDB.rd["Kalorie"].ToString();
        //            KalorieString = AzureDB.rd["Kalorie"].ToString();
        //        }
        //        AzureDB.closeConnection();


        //        Dekorator.Posilek sniadanie2 = new Dekorator.Sniadanie();
        //        sniadanie2 = new Dekorator.PosilekDekorator(sniadanie2);

        //    }
        //    catch (Exception ex)
        //    {

        //        message2 = ex.Message.ToString();
        //    }






        //    //Zapotrzebowanie dzienne
        //    String message = "Nie udało się wyliczyć zapotrzebowania dziennego";
        //    try
        //    {
        //        //Harris-Benedict
        //        //Mężczyźni: 66.5 + (13.75 * waga) + (5.003 * wzrost) - (6.775 * wiek) Kobiety: 655.1 + (9.563 * waga) + (1.85 * wzrost)-(4.676 * wiek)
        //        double DzienneZapotrzebowanie = 0;
        //        if (FunkcjeGlobalne.Plec == "M")
        //        {
        //            DzienneZapotrzebowanie = 66.5 + (13.75 * Convert.ToDouble(FunkcjeGlobalne.Waga)) + (5.003 * Convert.ToDouble(FunkcjeGlobalne.Wzrost)) - (6.775 * Convert.ToDouble(FunkcjeGlobalne.Wiek));
        //        }
        //        else
        //        {
        //            DzienneZapotrzebowanie = 655.1 + (9.563 * Convert.ToDouble(FunkcjeGlobalne.Waga)) + (1.85 * Convert.ToDouble(FunkcjeGlobalne.Wzrost)) - (4.676 * Convert.ToDouble(FunkcjeGlobalne.Wiek));
        //        }
        //        //Do drugiego miejsca po przecinku
        //        double Bialka = Math.Round((Double)DzienneZapotrzebowanie * 0.15, 2);
        //        double Kalorie = Math.Round((Double)DzienneZapotrzebowanie, 2);
        //        double Tluszcze = Math.Round((Double)DzienneZapotrzebowanie * 0.30, 2);
        //        double Weglowodany = Math.Round((Double)DzienneZapotrzebowanie * 0.55, 2);

        //        TextBoxKalorie.Text = "Kalorie: Ile / " + Kalorie + " kcal";
        //        TextBoxBialka.Text = "Białka: Ile / " + Bialka + " g";
        //        TextBoxTluszcze.Text = "Tłuszcze: Ile / " + Tluszcze + " g";
        //        TextBoxWeglowodany.Text = "Węglowodany: Ile / " + Weglowodany + " g";

        //    }
        //    catch (Exception ex)
        //    {

        //        message = ex.Message.ToString();
        //    }

        }
    }
}

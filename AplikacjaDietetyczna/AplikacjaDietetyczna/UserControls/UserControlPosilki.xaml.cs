﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

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

        private void Czyszczenie()
        {
            SniadanieTekst.Text = "  ";
            ObiadTekst.Text = "  ";
            LunchTekst.Text = "  ";
            KolacjaTekst.Text = "  ";
            PrzekaskaTekst.Text = "  ";
            SniadanieKalorie.Text = "0 kcal";
            ObiadKalorie.Text = "0 kcal";
            LunchKalorie.Text = "0 kcal";
            PrzekaskaKalorie.Text = "0 kcal";
            KolacjaKalorie.Text = "0 kcal";
        }

        private void Posilki()
        {

            int TypPosilku = 1;
            double SniadanieKalorieD = 0;
            double SniadanieWeglowodanyD = 0;
            double SniadanieBialkaD = 0;
            double SniadanieTluszczeD = 0;

            string sqlFormattedDate = GetDate(Convert.ToInt32(FunkcjeGlobalne.Data)).ToString("yyyy-MM-dd");
            string SniadanieProdukty = "";
            string SniadanieNazwa = "";
            int SniadanieIlosc = 0;
            string SniadaniePodanie = "";
            string SniadanieBebg = "";
            string Dwa = ""; //Jak są przynajmniej dwa posiłki w trakcie jednego np. obiadu to służy do łączenia
            TextBoxCurrentDate.Text = sqlFormattedDate;
            String message2 = "Nie udalo sie pobrac danych do dekoratora";
            try
            {
               
                Dekorator.Posilek sniadanie = new Dekorator.TypPosilku();
                sniadanie = new Dekorator.ProduktDekorator(sniadanie);

                while (TypPosilku < 6)
                {
                    


                    AzureDB.openConnection();
                    AzureDB.sql = "SELECT Nazwa, NazwaProduktu, Podanie, Ilosc, Kalorie,TypPosilku, Weglowodany, Bialka, Tluszcze FROM Users  INNER JOIN Posilki ON Posilki.ID_User = Users.ID_User INNER JOIN PosilkiProdukty ON Posilki.ID_Posilku = PosilkiProdukty.ID_Posilku INNER JOIN Produkty ON Produkty.ID_Produktu = PosilkiProdukty.ID_Produktu WHERE Users.ID_User = 20 AND Data = '" + sqlFormattedDate + "' AND TypPosilku = '" + TypPosilku + "' ";
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.rd = AzureDB.cmd.ExecuteReader();

                    if (AzureDB.rd.HasRows)
                    {
                        while (AzureDB.rd.Read())
                        {
                            SniadanieIlosc = Convert.ToInt32(AzureDB.rd["Ilosc"].ToString());
                            SniadanieKalorieD += sniadanie.Calculate(Convert.ToDouble(AzureDB.rd["Kalorie"].ToString()), SniadanieIlosc);
                            SniadanieWeglowodanyD += sniadanie.Calculate(Convert.ToDouble(AzureDB.rd["Weglowodany"].ToString()), SniadanieIlosc);
                            SniadanieBialkaD += sniadanie.Calculate(Convert.ToDouble(AzureDB.rd["Bialka"].ToString()), SniadanieIlosc);
                            SniadanieTluszczeD += sniadanie.Calculate(Convert.ToDouble(AzureDB.rd["Tluszcze"].ToString()), SniadanieIlosc);
                            if (SniadanieNazwa != AzureDB.rd["Nazwa"].ToString())
                            {
                                Dwa += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
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


                    if (TypPosilku == 5)
                    {
                        KolacjaTekst.Text += Dwa;
                        KolacjaTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                        if (KolacjaTekst.Text != "")
                        {
                            KolacjaTekst.Text = KolacjaTekst.Text.Remove(KolacjaTekst.Text.Length - 2);
                        }
                       // KolacjaTekst.Text = KolacjaTekst.Text.Remove(KolacjaTekst.Text.Length - 2);
                        KolacjaKalorie.Text = Convert.ToString(SniadanieKalorieD) + " kcal";
                        KolacjaWeglowodany.Text = Convert.ToString(SniadanieWeglowodanyD) + " g";
                        KolacjaTluszcze.Text = Convert.ToString(SniadanieTluszczeD) + " g";
                        KolacjaBialka.Text = Convert.ToString(SniadanieBialkaD) + " g";

                        TypPosilku++;
                    }



                    if (TypPosilku == 4)
                    {
                        PrzekaskaTekst.Text += Dwa;
                        PrzekaskaTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                        if (PrzekaskaTekst.Text != "")
                        {
                            PrzekaskaTekst.Text = PrzekaskaTekst.Text.Remove(PrzekaskaTekst.Text.Length - 2);
                        }
                        //PrzekaskaTekst.Text = PrzekaskaTekst.Text.Remove(PrzekaskaTekst.Text.Length - 2);
                        PrzekaskaKalorie.Text = Convert.ToString(SniadanieKalorieD) + " kcal";
                        PrzekaskaWeglowodany.Text = Convert.ToString(SniadanieWeglowodanyD) + " g";
                        PrzekaskaTluszcze.Text = Convert.ToString(SniadanieTluszczeD) + " g";
                        PrzekaskaBialka.Text = Convert.ToString(SniadanieBialkaD) + " g";

                        TypPosilku++;
                    }


                    if (TypPosilku == 3)
                    {
                        ObiadTekst.Text += Dwa;
                        ObiadTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                        if (ObiadTekst.Text != "")
                        {
                            ObiadTekst.Text = ObiadTekst.Text.Remove(ObiadTekst.Text.Length - 2);
                        }
                        
                        ObiadKalorie.Text = Convert.ToString(SniadanieKalorieD) + " kcal";
                        ObiadWeglowodany.Text = Convert.ToString(SniadanieWeglowodanyD) + " g";
                        ObiadTluszcze.Text = Convert.ToString(SniadanieTluszczeD) + " g";
                        ObiadBialka.Text = Convert.ToString(SniadanieBialkaD) + " g";
                        TypPosilku++;
                    }


                    if (TypPosilku == 2)
                    {
                        LunchTekst.Text += Dwa;
                        LunchTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                        if(LunchTekst.Text != "")
                        {
                            LunchTekst.Text = LunchTekst.Text.Remove(LunchTekst.Text.Length - 2);
                        }
                       
                        LunchKalorie.Text = Convert.ToString(SniadanieKalorieD) + " kcal";
                        LunchWeglowodany.Text = Convert.ToString(SniadanieWeglowodanyD) + " g";
                        LunchTluszcze.Text = Convert.ToString(SniadanieTluszczeD) + " g";
                        LunchBialka.Text = Convert.ToString(SniadanieBialkaD) + " g";
                        TypPosilku++;
                    }


                    if (TypPosilku == 1)
                    {
                        SniadanieTekst.Text += Dwa;
                        SniadanieTekst.Text += sniadanie.GetFullName(SniadanieNazwa, SniadanieBebg);
                        SniadanieTekst.Text = SniadanieTekst.Text.Remove(SniadanieTekst.Text.Length - 2);
                        SniadanieKalorie.Text = Convert.ToString(SniadanieKalorieD) + " kcal";
                        SniadanieWeglowodany.Text = Convert.ToString(SniadanieWeglowodanyD) + " g";
                        SniadanieTluszcze.Text = Convert.ToString(SniadanieTluszczeD) + " g";
                        SniadanieBialka.Text = Convert.ToString(SniadanieBialkaD) + " g";
                        TypPosilku++;
                    }


                    SniadanieBebg = "";
                    SniadanieProdukty = "";
                    SniadanieKalorieD = 0;
                    SniadanieNazwa = "";
                    SniadanieWeglowodanyD = 0;
                    SniadanieBialkaD = 0;
                    SniadanieTluszczeD = 0;
                    Dwa = "";
                }



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




        private void Window_LoadedZapotrzebowanie(object sender, RoutedEventArgs e)
        {
            Posilki();

        }

        private void MinusDay(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.CurrentDate = Convert.ToInt32(FunkcjeGlobalne.Data);
            FunkcjeGlobalne.Data = Convert.ToString(FunkcjeGlobalne.CurrentDate - 1);
            Czyszczenie();
            Posilki();
            
           

        }

        private void PlusDay(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.CurrentDate = Convert.ToInt32(FunkcjeGlobalne.Data);

            FunkcjeGlobalne.Data = Convert.ToString(FunkcjeGlobalne.CurrentDate + 1);
           Czyszczenie();
            Posilki();


        }
    }
}

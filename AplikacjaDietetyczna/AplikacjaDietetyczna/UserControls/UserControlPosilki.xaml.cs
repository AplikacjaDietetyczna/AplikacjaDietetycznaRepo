using System;
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

      


        private void Czyszczenie()
        {
            SniadanieTekst.Text = "";
            ObiadTekst.Text = "";
            LunchTekst.Text = "";
            KolacjaTekst.Text = "";
            PrzekaskaTekst.Text = "";
            SniadanieKalorie.Text = "0 kcal";
            ObiadKalorie.Text = "0 kcal";
            LunchKalorie.Text = "0 kcal";
            PrzekaskaKalorie.Text = "0 kcal";
            KolacjaKalorie.Text = "0 kcal";
        }

        private void Posilki()
        {

            int TypPosilku = 1;
            double PosilekKalorieD = 0;
            double PosilekWeglowodanyD = 0;
            double PosilekBialkaD = 0;
            double PosilekTluszczeD = 0;
            double BialkaZjedzone = 0;
            double WeglowodanyZjedzone = 0;
            double KalorieZjedzone = 0;
            double TluszczeZjedzone = 0;
            string sqlFormattedDate = DateKlasa.GetDate(Convert.ToInt32(FunkcjeGlobalne.Data)).ToString("yyyy-MM-dd");
            string PosilekProdukty = "";
            string PosilekNazwa = "";
            int PosilekIlosc = 0;
            string PosilekPodanie = "";
            string PosilekLaczenie = "";
            string Dwa = ""; //Jak są przynajmniej dwa posiłki w trakcie jednego np. obiadu to służy do łączenia
            TextBoxCurrentDate.Text = sqlFormattedDate;
            String message2 = "Nie udalo sie pobrac danych do dekoratora";
            try
            {
               
                Dekorator.Posilek posilek = new Dekorator.TypPosilku();
                posilek = new Dekorator.ProduktDekorator(posilek);

                while (TypPosilku < 6)
                {
                    


                    AzureDB.openConnection();
                    AzureDB.sql = "SELECT Nazwa, NazwaProduktu, Podanie, Ilosc, Kalorie,TypPosilku, Weglowodany, Bialka, Tluszcze FROM Users  INNER JOIN Posilki ON Posilki.ID_User = Users.ID_User INNER JOIN PosilkiProdukty ON Posilki.ID_Posilku = PosilkiProdukty.ID_Posilku INNER JOIN Produkty ON Produkty.ID_Produktu = PosilkiProdukty.ID_Produktu WHERE Users.ID_User = '" +FunkcjeGlobalne.ID+"' AND Data = '" + sqlFormattedDate + "' AND TypPosilku = '" + TypPosilku + "' ";
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.rd = AzureDB.cmd.ExecuteReader();

                    if (AzureDB.rd.HasRows)
                    {
                        while (AzureDB.rd.Read())
                        {
                            PosilekIlosc = Convert.ToInt32(AzureDB.rd["Ilosc"].ToString());
                            PosilekKalorieD += posilek.Calculate(Convert.ToDouble(AzureDB.rd["Kalorie"].ToString()), PosilekIlosc);
                            PosilekWeglowodanyD += posilek.Calculate(Convert.ToDouble(AzureDB.rd["Weglowodany"].ToString()), PosilekIlosc);
                            PosilekBialkaD += posilek.Calculate(Convert.ToDouble(AzureDB.rd["Bialka"].ToString()), PosilekIlosc);
                            PosilekTluszczeD += posilek.Calculate(Convert.ToDouble(AzureDB.rd["Tluszcze"].ToString()), PosilekIlosc);
                            if (PosilekNazwa != AzureDB.rd["Nazwa"].ToString())
                            {
                                Dwa += posilek.GetFullName(PosilekNazwa, PosilekLaczenie);
                                PosilekLaczenie = "";
                            }
                            PosilekNazwa = AzureDB.rd["Nazwa"].ToString();
                            PosilekProdukty = AzureDB.rd["NazwaProduktu"].ToString();
                            PosilekProdukty += ", ";
                            PosilekIlosc = Convert.ToInt32(AzureDB.rd["Ilosc"].ToString());
                            PosilekPodanie = AzureDB.rd["Podanie"].ToString();
                            PosilekLaczenie += posilek.GetName(PosilekProdukty, PosilekIlosc, PosilekPodanie);



                        }
                    }
                    AzureDB.closeConnection();


                    if (TypPosilku == 5)
                    {
                        KolacjaTekst.Text += Dwa;
                        KolacjaTekst.Text += posilek.GetFullName(PosilekNazwa, PosilekLaczenie);
                        if (KolacjaTekst.Text != "")
                        {
                            KolacjaTekst.Text = KolacjaTekst.Text.Remove(KolacjaTekst.Text.Length - 2);
                        }
                       // KolacjaTekst.Text = KolacjaTekst.Text.Remove(KolacjaTekst.Text.Length - 2);
                        KolacjaKalorie.Text = Convert.ToString(PosilekKalorieD) + " kcal";
                        KolacjaWeglowodany.Text = Convert.ToString(PosilekWeglowodanyD) + " g";
                        KolacjaTluszcze.Text = Convert.ToString(PosilekTluszczeD) + " g";
                        KolacjaBialka.Text = Convert.ToString(PosilekBialkaD) + " g";
                        BialkaZjedzone += PosilekBialkaD;
                        WeglowodanyZjedzone += PosilekWeglowodanyD;
                        KalorieZjedzone += PosilekKalorieD;
                        TluszczeZjedzone += PosilekTluszczeD;

                        TypPosilku++;
                    }



                    if (TypPosilku == 4)
                    {
                        PrzekaskaTekst.Text += Dwa;
                        PrzekaskaTekst.Text += posilek.GetFullName(PosilekNazwa, PosilekLaczenie);
                        if (PrzekaskaTekst.Text != "")
                        {
                            PrzekaskaTekst.Text = PrzekaskaTekst.Text.Remove(PrzekaskaTekst.Text.Length - 2);
                        }
                        //PrzekaskaTekst.Text = PrzekaskaTekst.Text.Remove(PrzekaskaTekst.Text.Length - 2);
                        PrzekaskaKalorie.Text = Convert.ToString(PosilekKalorieD) + " kcal";
                        PrzekaskaWeglowodany.Text = Convert.ToString(PosilekWeglowodanyD) + " g";
                        PrzekaskaTluszcze.Text = Convert.ToString(PosilekTluszczeD) + " g";
                        PrzekaskaBialka.Text = Convert.ToString(PosilekBialkaD) + " g";
                        BialkaZjedzone += PosilekBialkaD;
                        WeglowodanyZjedzone += PosilekWeglowodanyD;
                        KalorieZjedzone += PosilekKalorieD;
                        TluszczeZjedzone += PosilekTluszczeD; ;

                        TypPosilku++;
                    }


                    if (TypPosilku == 3)
                    {
                        ObiadTekst.Text += Dwa;
                        ObiadTekst.Text += posilek.GetFullName(PosilekNazwa, PosilekLaczenie);
                        if (ObiadTekst.Text != "")
                        {
                            ObiadTekst.Text = ObiadTekst.Text.Remove(ObiadTekst.Text.Length - 2);
                        }
                        
                        ObiadKalorie.Text = Convert.ToString(PosilekKalorieD) + " kcal";
                        ObiadWeglowodany.Text = Convert.ToString(PosilekWeglowodanyD) + " g";
                        ObiadTluszcze.Text = Convert.ToString(PosilekTluszczeD) + " g";
                        ObiadBialka.Text = Convert.ToString(PosilekBialkaD) + " g";
                        BialkaZjedzone += PosilekBialkaD;
                        WeglowodanyZjedzone += PosilekWeglowodanyD;
                        KalorieZjedzone += PosilekKalorieD;
                        TluszczeZjedzone += PosilekTluszczeD;
                        TypPosilku++;
                    }


                    if (TypPosilku == 2)
                    {
                        LunchTekst.Text += Dwa;
                        LunchTekst.Text += posilek.GetFullName(PosilekNazwa, PosilekLaczenie);
                        if(LunchTekst.Text != "")
                        {
                            LunchTekst.Text = LunchTekst.Text.Remove(LunchTekst.Text.Length - 2);
                        }
                       
                        LunchKalorie.Text = Convert.ToString(PosilekKalorieD) + " kcal";
                        LunchWeglowodany.Text = Convert.ToString(PosilekWeglowodanyD) + " g";
                        LunchTluszcze.Text = Convert.ToString(PosilekTluszczeD) + " g";
                        LunchBialka.Text = Convert.ToString(PosilekBialkaD) + " g";
                        BialkaZjedzone += PosilekBialkaD;
                        WeglowodanyZjedzone += PosilekWeglowodanyD;
                        KalorieZjedzone += PosilekKalorieD;
                        TluszczeZjedzone += PosilekTluszczeD;
                        TypPosilku++;
                    }


                    if (TypPosilku == 1)
                    {
                        SniadanieTekst.Text += Dwa;
                        SniadanieTekst.Text += posilek.GetFullName(PosilekNazwa, PosilekLaczenie);
                        if (SniadanieTekst.Text != "")
                        {
                            SniadanieTekst.Text = SniadanieTekst.Text.Remove(SniadanieTekst.Text.Length - 2);
                        }

                        SniadanieKalorie.Text = Convert.ToString(PosilekKalorieD) + " kcal";
                        SniadanieWeglowodany.Text = Convert.ToString(PosilekWeglowodanyD) + " g";
                        SniadanieTluszcze.Text = Convert.ToString(PosilekTluszczeD) + " g";
                        SniadanieBialka.Text = Convert.ToString(PosilekBialkaD) + " g";
                        BialkaZjedzone += PosilekBialkaD;
                        WeglowodanyZjedzone += PosilekWeglowodanyD;
                        KalorieZjedzone += PosilekKalorieD;
                        TluszczeZjedzone += PosilekTluszczeD;
                        TypPosilku++;
                    }


                    PosilekLaczenie = "";
                    PosilekProdukty = "";
                    PosilekKalorieD = 0;
                    PosilekNazwa = "";
                    PosilekWeglowodanyD = 0;
                    PosilekBialkaD = 0;
                    PosilekTluszczeD = 0;
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

              double DzienneZapotrzebowanie =  Zapotrzebowanie.GetZapotrzebowanie();

                double Kalorie = Zapotrzebowanie.GetKalorie();
                double Bialka = Zapotrzebowanie.GetBialka();
                double Tluszcze = Zapotrzebowanie.GetTluszcze();
                double Weglowodany = Zapotrzebowanie.GetWeglowodany();

                TextBoxKalorie.Text = "Kalorie: " + KalorieZjedzone + " / " + Kalorie + " kcal";
                TextBoxBialka.Text = "Białka: "+BialkaZjedzone+" / " + Bialka + " g";
                TextBoxTluszcze.Text = "Tłuszcze: " + TluszczeZjedzone + " / " + Tluszcze + " g";
                TextBoxWeglowodany.Text = "Węglowodany: " + WeglowodanyZjedzone + " / " + Weglowodany + " g";

                //Dodatkowe wyświetlanie czy user je zdrowo

                if((KalorieZjedzone > Kalorie + 800))
                {
                    TextBoxKalorie.BorderThickness = new Thickness(1);
                    TextBoxKalorie.BorderBrush = Brushes.Red;
                    TextBoxKalorie.ToolTip = new ToolTip().Content = "Jeśli chcesz utrzymać swoją obecną wagę musisz ograniczyć ilość spożywanych kalorii";
                }

                if ((KalorieZjedzone < Kalorie + 800 && KalorieZjedzone > Kalorie - 200))
                {
                    TextBoxKalorie.BorderThickness = new Thickness(1);
                    TextBoxKalorie.BorderBrush = Brushes.Green;
                    TextBoxKalorie.ToolTip = new ToolTip().Content = "Trzymaj tak dalej";
                }

                else if (KalorieZjedzone < Kalorie)
                {
                    TextBoxKalorie.BorderThickness = new Thickness(0);
                    TextBoxKalorie.ToolTip = new ToolTip().Content = "Jeszcze nie udało Ci się zjeść wystarczająco";
                }

                if ((BialkaZjedzone > Bialka + 90))
                {
                    TextBoxBialka.BorderThickness = new Thickness(1);
                    TextBoxBialka.BorderBrush = Brushes.Red;
                    TextBoxBialka.ToolTip = new ToolTip().Content = "Jeśli chcesz utrzymać swoją obecną wagę musisz ograniczyć ilość spożywanego białka";
                }

                if ((BialkaZjedzone < Bialka + 90 && BialkaZjedzone > Bialka - 55))
                {
                    TextBoxBialka.BorderThickness = new Thickness(1);
                    TextBoxBialka.BorderBrush = Brushes.Green;
                    TextBoxBialka.ToolTip = new ToolTip().Content = "Trzymaj tak dalej";
                }

                else if (BialkaZjedzone < Bialka)
                {
                    TextBoxBialka.BorderThickness = new Thickness(0);
                    TextBoxBialka.ToolTip = new ToolTip().Content = "Jeszcze nie udało ci się zjeść wystarczająco";
                }


                if ((TluszczeZjedzone > Tluszcze + 50))
                {
                    TextBoxTluszcze.BorderThickness = new Thickness(1);
                    TextBoxTluszcze.BorderBrush = Brushes.Red;
                    TextBoxTluszcze.ToolTip = new ToolTip().Content = "Jeśli chcesz utrzymać swoją obecną wagę musisz ograniczyć ilość spożywanych tłuszczy";
                }

                if ((TluszczeZjedzone < Tluszcze + 15 && TluszczeZjedzone > Tluszcze - 15))
                {
                    TextBoxTluszcze.BorderThickness = new Thickness(1);
                    TextBoxTluszcze.BorderBrush = Brushes.Green;
                    TextBoxTluszcze.ToolTip = new ToolTip().Content = "Trzymaj tak dalej";
                }

                else if (TluszczeZjedzone < Tluszcze)
                {
                    TextBoxTluszcze.BorderThickness = new Thickness(0);
                    TextBoxTluszcze.ToolTip = new ToolTip().Content = "Jeszcze nie udało ci się zjeść wystarczająco";
                }

                if ((WeglowodanyZjedzone > Weglowodany + 400))
                {
                    TextBoxWeglowodany.BorderThickness = new Thickness(1);
                    TextBoxWeglowodany.BorderBrush = Brushes.Red;
                    TextBoxWeglowodany.ToolTip = new ToolTip().Content = "Jeśli chcesz utrzymać swoją obecną wagę musisz ograniczyć ilość spożywanych węglowodanów";
                }

                if ((WeglowodanyZjedzone < Weglowodany + 400 && WeglowodanyZjedzone > Weglowodany - 170))
                {
                    TextBoxWeglowodany.BorderThickness = new Thickness(1);
                    TextBoxWeglowodany.BorderBrush = Brushes.Green;
                    TextBoxWeglowodany.ToolTip = new ToolTip().Content = "Trzymaj tak dalej";
                }

                else if (WeglowodanyZjedzone < Weglowodany)
                {
                    TextBoxWeglowodany.BorderThickness = new Thickness(0);
                    TextBoxWeglowodany.ToolTip = new ToolTip().Content = "Jeszcze nie udało ci się zjeść wystarczająco";
                }





            }
            catch (Exception ex)
            {

                message = ex.Message.ToString();
            }








        }






        private void Window_LoadedZapotrzebowanie(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.Data = "0";
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

        private void SniadanieDodaj_Click(object sender, RoutedEventArgs e)
        {

            FunkcjeGlobalne.SelectedDate = TextBoxCurrentDate.Text;
            FunkcjeGlobalne.SelectedPosilek = 1;

            UserControl add = new UserControls.UserControlDodaj();
            GridMain.Children.Add(add);


        }

        private void LunchDodaj_Click(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.SelectedDate = TextBoxCurrentDate.Text;
            FunkcjeGlobalne.SelectedPosilek = 2;

            UserControl add = new UserControls.UserControlDodaj();
            GridMain.Children.Add(add);
        }

        private void ObiadDodaj_Click(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.SelectedDate = TextBoxCurrentDate.Text;
            FunkcjeGlobalne.SelectedPosilek = 3;

            UserControl add = new UserControls.UserControlDodaj();
            GridMain.Children.Add(add);
        }

        private void PrzekaskaDodaj_Click(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.SelectedDate = TextBoxCurrentDate.Text;
            FunkcjeGlobalne.SelectedPosilek = 4;

            UserControl add = new UserControls.UserControlDodaj();
            GridMain.Children.Add(add);
        }

        private void KolacjaDodaj_Click(object sender, RoutedEventArgs e)
        {
            FunkcjeGlobalne.SelectedDate = TextBoxCurrentDate.Text;
            FunkcjeGlobalne.SelectedPosilek = 5;

            UserControl add = new UserControls.UserControlDodaj();
            GridMain.Children.Add(add);
        }
    }
}

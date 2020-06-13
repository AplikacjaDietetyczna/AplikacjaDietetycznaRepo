 using AplikacjaDietetyczna.Klasy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikacjaDietetyczna.UserControls
{

    /// <summary>
    /// Interaction logic for UserControlDodaj.xaml
    /// </summary>
    public partial class UserControlDodaj : UserControl
    {
        public ObservableCollection<ComboBoxItem> cbItems1 { get; set; }//potrzebne do uzupełniania comboboxow
        public ComboBoxItem SelectedcbItem1 { get; set; }//potrzebne do uzupełniania comboboxow
        public string zapytaniePosilek = "";
        public string zapytanieProdukty = "";
        public List<string> ProduktID = new List<string>();
        public List<string> ProduktNazwa = new List<string>();
        public List<string> ProduktIlosc = new List<string>();
        public List<int> Kalorie = new List<int>();
        public List<int> Weglowodany = new List<int>();
        public List<int> Tluszcze = new List<int>();
        public List<int> Bialka = new List<int>();
        public int Kalorie_P = 0;
        public int Weglowodany_P = 0;
        public int Tluszcze_P = 0;
        public int Bialka_P = 0;
        string IDUzytkownika = FunkcjeGlobalne.ID;


        private void UzupelnijComboBoxy()//uzupelnia combobox produktow wszystkimi dostepnymi w bazie danych produktami
        {
            DataContext = this;
            cbItems1 = new ObservableCollection<ComboBoxItem>();
            var cbItem1 = new ComboBoxItem { Content = "Wybierz produkt" };
            SelectedcbItem1 = cbItem1;
            cbItems1.Add(cbItem1);
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Produkty order by NazwaProduktu";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            foreach (DataRow dataRow in AzureDB.dt.Rows)
            {
                cbItems1.Add(new ComboBoxItem { Content = dataRow["NazwaProduktu"].ToString(), Tag = dataRow["ID_Produktu"].ToString() });
            }
            AzureDB.closeConnection();

        }
        public UserControlDodaj()
        {
            InitializeComponent();
            UzupelnijComboBoxy();
        }

        private void ProduktCombo_DropDownClosed(object sender, EventArgs e)//uzupelnia pierwsze pole ilosci jak liczona jest ilosc danego produktu
        {
            FillGhost();
            IloscCombo.Items.Clear();
            String podanie = "";
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Produkty WHERE NazwaProduktu='" + ProduktCombo.Text.ToString() + "'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            if (AzureDB.dt.Rows.Count > 0)
            {
                podanie = AzureDB.dt.Rows[0]["Podanie"].ToString();
                Podsumowanie_Ghost.Text += "Produkt: " + AzureDB.dt.Rows[0]["NazwaProduktu"].ToString() + "\n";
                Podsumowanie_Ghost.Text += "Ilość: 1\n";
                Podsumowanie_Ghost.Text += "Wartości odżywcze: Białko: " + Convert.ToInt32(AzureDB.dt.Rows[0]["Bialka"]) + " Węglowodany: " + Convert.ToInt32(AzureDB.dt.Rows[0]["Weglowodany"]) + " Tłuszcze: " + Convert.ToInt32(AzureDB.dt.Rows[0]["Tluszcze"]) + " Kalorie: "+Convert.ToInt32(AzureDB.dt.Rows[0]["Kalorie"]) + "\n\n";
            }
            AzureDB.closeConnection();
            IloscCombo.Items.Add("Ilośćx(" + podanie + ")");
            for (int i = 1; i < 11; i++)
            {
                IloscCombo.Items.Add(new ComboBoxItem { Content = i });
            }
            IloscCombo.SelectedIndex = 0;
        }
        private void ClearFields()
        {
            IloscCombo.SelectedIndex = 0;
            ProduktCombo.SelectedIndex = 0;
            ProduktID.Clear();
            ProduktNazwa.Clear();
            ProduktIlosc.Clear();
            Kalorie.Clear();
            Weglowodany.Clear();
            Tluszcze.Clear();
            Bialka.Clear();
            Podsumowanie.Text = "";
            NazwaPosilkuText.Text = "";
            Białko_Podsumowanie.Text = "Białko: ";
            Kalorie_Podsumowanie.Text = "Kalorie: ";
            Tluszcze_Podsumowanie.Text = "Tłuszcze: ";
            Weglowodany_Podsumowanie.Text = "Węglowodany: ";
            Kalorie_P = 0;
            Weglowodany_P = 0;
            Bialka_P = 0;
            Tluszcze_P = 0;
        }
        private void FillGhost()
        {
            Podsumowanie_Ghost.Text = "";
            for (int i = 0; i < ProduktID.Count; i++)
            {
                Podsumowanie_Ghost.Text += "\n";
                Podsumowanie_Ghost.Text += "\n";
                Podsumowanie_Ghost.Text += "\n\n";
            }
        }
        private void FillFields()
        {
            Podsumowanie.Text = "";
            IloscCombo.SelectedIndex = 0;
            ProduktCombo.SelectedIndex = 0;
            for (int i = 0; i < ProduktID.Count; i++)
            {
                Podsumowanie.Text += "Produkt: " + ProduktNazwa[i] + "\n";
                Podsumowanie.Text += "Ilość: " + ProduktIlosc[i] + "\n";
                Podsumowanie.Text += "Wartości odżywcze: Białko: " + Bialka[i] + " Węglowodany: " + Weglowodany[i] + " Tłuszcze: " + Tluszcze[i] + " Kalorie: " + Kalorie[i] + "\n\n";
            }
            Kalorie_P = Kalorie.Sum();
            Weglowodany_P = Weglowodany.Sum();
            Bialka_P = Bialka.Sum();
            Tluszcze_P = Tluszcze.Sum();
            Białko_Podsumowanie.Text = "Białko: " + Bialka_P + "g";
            Kalorie_Podsumowanie.Text = "Kalorie: " + Kalorie_P + "kcal";
            Tluszcze_Podsumowanie.Text = "Tłuszcze: " + Tluszcze_P + "g";
            Weglowodany_Podsumowanie.Text = "Węglowodany: " + Weglowodany_P + "g";
            IloscCombo.Items.Clear();
            FillGhost();
        }


        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void DodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            if (ProduktCombo.SelectedIndex != 0 && IloscCombo.SelectedIndex != 0)
            {
                ProduktID.Add(((ComboBoxItem)ProduktCombo.SelectedItem).Tag.ToString());
                ProduktIlosc.Add(IloscCombo.Text);
                if (ProduktID.Count != ProduktID.Distinct().Count())//wymagane bo klucz glowny na polach(id_produktu i idposilku) nie przepuszcza 2 takich samych produktow do posilku
                {
                    ProduktID.RemoveAt(ProduktID.Count - 1);
                    ProduktIlosc.RemoveAt(ProduktIlosc.Count - 1);
                    MessageBox.Show("W posiłku nie mogą być 2 takie same produkty", "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    AzureDB.openConnection();
                    AzureDB.sql = "Select * from Produkty WHERE NazwaProduktu='" + ProduktCombo.Text.ToString() + "'";
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                    AzureDB.dt = new DataTable();
                    AzureDB.da.Fill(AzureDB.dt);
                    if (AzureDB.dt.Rows.Count > 0)
                    {
                        ProduktNazwa.Add(AzureDB.dt.Rows[0]["NazwaProduktu"].ToString());
                        Kalorie.Add(Convert.ToInt16(AzureDB.dt.Rows[0]["Kalorie"]) * Convert.ToInt16(IloscCombo.Text));
                        Weglowodany.Add(Convert.ToInt16(AzureDB.dt.Rows[0]["Weglowodany"]) * Convert.ToInt16(IloscCombo.Text));
                        Tluszcze.Add(Convert.ToInt16(AzureDB.dt.Rows[0]["Tluszcze"]) * Convert.ToInt16(IloscCombo.Text));
                        Bialka.Add(Convert.ToInt16(AzureDB.dt.Rows[0]["Bialka"]) * Convert.ToInt16(IloscCombo.Text));
                    }
                    AzureDB.closeConnection();
                    FillFields();
                    Podsumowanie_Ghost.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Prosze wybrać poprawną ilość lub produkt", "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void DodajPosilek_Click(object sender, RoutedEventArgs e)
        {
            if (NazwaPosilkuText.Text != "" && Podsumowanie.Text != "")
            {
                try
                {
                    string IdPosilku = "";
                    zapytaniePosilek = "INSERT INTO Posilki (ID_User,Nazwa,TypPosilku,Data) VALUES("+IDUzytkownika+", '" + NazwaPosilkuText.Text + "', " + FunkcjeGlobalne.SelectedPosilek + ",'"+FunkcjeGlobalne.SelectedDate +"')";
                    zapytanieProdukty = "";
                    AzureDB.openConnection();
                    AzureDB.sql = zapytaniePosilek;
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.cmd.ExecuteNonQuery();
                    AzureDB.closeConnection();
                    AzureDB.openConnection();
                    AzureDB.sql = "SELECT TOP 1 * FROM Posilki ORDER BY ID_Posilku DESC";
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                    AzureDB.dt = new DataTable();
                    AzureDB.da.Fill(AzureDB.dt);
                    if (AzureDB.dt.Rows.Count > 0)
                    {
                        IdPosilku = AzureDB.dt.Rows[0]["ID_Posilku"].ToString();
                    }
                    AzureDB.closeConnection();
                    AzureDB.openConnection();
                    for (int i = 0; i < ProduktID.Count; i++)
                    {
                        zapytanieProdukty = "INSERT INTO PosilkiProdukty(ID_Posilku,ID_Produktu,Ilosc) VALUES(" + IdPosilku + ", " + ProduktID[i] + ", " + ProduktIlosc[i] + ")";
                        AzureDB.sql = zapytanieProdukty;
                        AzureDB.cmd.CommandType = CommandType.Text;
                        AzureDB.cmd.CommandText = AzureDB.sql;
                        AzureDB.cmd.ExecuteNonQuery();
                    }
                    AzureDB.closeConnection();
                    MessageBox.Show("Posiłek został prawidołowo dodany", "Posiłek", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd: " + ex.Message, "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Prosze podaj nazwę/rodzaj posiłku lub dodaj conajmniej 1 produkt", "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NazwaPosilkuText_TextChanged(object sender, TextChangedEventArgs e)
        {
            NowyPosilek.Text = "Twoj nowy Posiłek: " + NazwaPosilkuText.Text;
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            ProduktID.RemoveAt(ProduktID.Count - 1);
            ProduktIlosc.RemoveAt(ProduktIlosc.Count - 1);
            ProduktNazwa.RemoveAt(ProduktNazwa.Count - 1);
            Kalorie.RemoveAt(Kalorie.Count - 1);
            Weglowodany.RemoveAt(Weglowodany.Count - 1);
            Tluszcze.RemoveAt(Tluszcze.Count - 1);
            Bialka.RemoveAt(Bialka.Count - 1);
            FillFields();

        }

        private void IloscCombo_DropDownClosed(object sender, EventArgs e)
        {
            if (IloscCombo.SelectedIndex != 0)
            {
                FillGhost();
                AzureDB.sql = "Select * from Produkty WHERE NazwaProduktu='" + ProduktCombo.Text.ToString() + "'";
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                AzureDB.dt = new DataTable();
                AzureDB.da.Fill(AzureDB.dt);
                if (AzureDB.dt.Rows.Count > 0)
                {
                    Podsumowanie_Ghost.Text += "Produkt: " + AzureDB.dt.Rows[0]["NazwaProduktu"].ToString() + "\n";
                    Podsumowanie_Ghost.Text += "Ilość: " + IloscCombo.Text + "\n";
                    Podsumowanie_Ghost.Text += "Wartości odżywcze: Białko: " + IloscCombo.SelectedIndex * Convert.ToInt32(AzureDB.dt.Rows[0]["Bialka"]) + " Węglowodany: " + IloscCombo.SelectedIndex * Convert.ToInt32(AzureDB.dt.Rows[0]["Weglowodany"]) + " Tłuszcze: " + IloscCombo.SelectedIndex * Convert.ToInt32(AzureDB.dt.Rows[0]["Tluszcze"]) + " Kalorie: " + IloscCombo.SelectedIndex * Convert.ToInt32(AzureDB.dt.Rows[0]["Kalorie"]) + "\n\n";
                }
                AzureDB.closeConnection();
            }

        }

        private void TypPosilku_Loaded(object sender, RoutedEventArgs e)
        {

            TypPosilku.Text = "Dodajesz ";

            if(FunkcjeGlobalne.SelectedPosilek == 1)
            {
                TypPosilku.Text += "posilek";
            }
            if (FunkcjeGlobalne.SelectedPosilek == 2)
            {
                TypPosilku.Text += "lunch";
            }
            if (FunkcjeGlobalne.SelectedPosilek == 3)
            {
                TypPosilku.Text += "obiad";
            }
            if (FunkcjeGlobalne.SelectedPosilek == 4)
            {
                TypPosilku.Text += "przekąskę";
            }
            if (FunkcjeGlobalne.SelectedPosilek == 5)
            {
                TypPosilku.Text += "kolację";
            }

        }
    }
}


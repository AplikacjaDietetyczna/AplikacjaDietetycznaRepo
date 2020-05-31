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
        public List<string> ProduktIlosc = new List<string>();
        public int Kalorie, Weglowodany, Tluszcze, Bialka;
        public int Kalorie_P = 0;
        public int Weglowodany_P = 0;
        public int Tluszcze_P = 0;
        public int Bialka_P = 0;


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
                cbItems1.Add(new ComboBoxItem { Content = dataRow["NazwaProduktu"].ToString() ,Tag = dataRow["ID_Produktu"].ToString() }) ;
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
            IloscCombo.Items.Clear();
            String podanie = "";
            AzureDB.openConnection();
            AzureDB.sql = "Select Podanie from Produkty WHERE NazwaProduktu='"+ProduktCombo.Text.ToString()+"'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            if (AzureDB.dt.Rows.Count > 0)
            {
                podanie = AzureDB.dt.Rows[0]["Podanie"].ToString();
            }
            AzureDB.closeConnection();
            IloscCombo.Items.Add("Ilośćx(" + podanie + ")");
            for(int i=1;i<11;i++)
            {
                IloscCombo.Items.Add(new ComboBoxItem { Content = i});
            }
            IloscCombo.SelectedIndex = 0;
        }
        private void ClearFields()
        {
            IloscCombo.SelectedIndex = 0;
            ProduktCombo.SelectedIndex = 0;
            RodzajPosilku.SelectedIndex = 0;
            ProduktID.Clear();
            ProduktIlosc.Clear();
            Podsumowanie.Text = "";
            Białko_Podsumowanie.Text = "Białko: ";
            Kalorie_Podsumowanie.Text = "Kalorie: ";
            Tluszcze_Podsumowanie.Text = "Tłuszcze: ";
            Weglowodany_Podsumowanie.Text = "Węglowodany: ";
            Kalorie_P = 0;
            Weglowodany_P = 0;
            Bialka_P = 0;
            Tluszcze_P = 0;
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
                        Kalorie = Convert.ToInt16(AzureDB.dt.Rows[0]["Kalorie"]) * Convert.ToInt16(IloscCombo.Text);
                        Weglowodany = Convert.ToInt16(AzureDB.dt.Rows[0]["Weglowodany"]) * Convert.ToInt16(IloscCombo.Text);
                        Tluszcze = Convert.ToInt16(AzureDB.dt.Rows[0]["Tluszcze"]) * Convert.ToInt16(IloscCombo.Text);
                        Bialka = Convert.ToInt16(AzureDB.dt.Rows[0]["Bialka"]) * Convert.ToInt16(IloscCombo.Text);
                    }
                    AzureDB.closeConnection();
                    Podsumowanie.Text += "Produkt: " + ProduktCombo.Text.ToString() + "\n";
                    Podsumowanie.Text += "Ilość: " + IloscCombo.Text.ToString() + "\n";
                    Podsumowanie.Text += "Wartości odżywcze: Białko: "+Bialka+" Węglowodany: "+Weglowodany+" Tłuszcze: "+Tluszcze+" Kalorie: "+Kalorie+"\n\n";
                    IloscCombo.SelectedIndex = 0;
                    ProduktCombo.SelectedIndex = 0;
                    Kalorie_P += Kalorie;
                    Weglowodany_P += Weglowodany;
                    Bialka_P +=Bialka;
                    Tluszcze_P +=Tluszcze;
                    Białko_Podsumowanie.Text = "Białko: "+Bialka_P+"g";
                    Kalorie_Podsumowanie.Text = "Kalorie: "+Kalorie_P+"kcal";
                    Tluszcze_Podsumowanie.Text = "Tłuszcze: "+Tluszcze_P+"g";
                    Weglowodany_Podsumowanie.Text = "Węglowodany: "+Weglowodany_P+"g";

                }
                }
                else
                {
                    MessageBox.Show("Prosze wybrać poprawną ilość lub produkt", "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
                }

        }

        private void DodajPosilek_Click(object sender, RoutedEventArgs e)
        {
            if (NazwaPosilkuText.Text != ""&&Podsumowanie.Text!=""&& ((ComboBoxItem)RodzajPosilku.SelectedItem).Tag.ToString()!="0")
            {
                try
                {
                    string IdPosilku = "";
                    zapytaniePosilek = "INSERT INTO Posilki (ID_User,Nazwa,TypPosilku,Data) VALUES(20, '" + NazwaPosilkuText.Text + "', " + ((ComboBoxItem)RodzajPosilku.SelectedItem).Tag.ToString() + ", GETDATE());";
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
                catch(Exception ex)
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
    }
}

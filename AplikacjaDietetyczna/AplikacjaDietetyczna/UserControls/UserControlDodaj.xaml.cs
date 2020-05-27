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


        private void UzupelnijComboBoxy()
        {
            DataContext = this;
            cbItems1 = new ObservableCollection<ComboBoxItem>();
            var cbItem1 = new ComboBoxItem { Content = "Wybierz produkt" };
            SelectedcbItem1 = cbItem1;
            cbItems1.Add(cbItem1);
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Produkty";
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

        private void ProduktCombo_DropDownClosed(object sender, EventArgs e)
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

        private void RodzajPosilku_Drop(object sender, EventArgs e)
        {
        }

        private void DodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            if(ProduktCombo.SelectedIndex!=0&&IloscCombo.SelectedIndex!=0)
            {
                Podsumowanie.Text += "Produkt: " + ProduktCombo.Text.ToString()+"\n";
                Podsumowanie.Text += "Ilość: " + IloscCombo.Text.ToString() + "\n\n";
                ProduktID.Add(((ComboBoxItem)ProduktCombo.SelectedItem).Tag.ToString());
                ProduktIlosc.Add(IloscCombo.Text);
                IloscCombo.SelectedIndex = 0;
                ProduktCombo.SelectedIndex = 0;
            }
        }

        private void DodajPosilek_Click(object sender, RoutedEventArgs e)
        {
            if (NazwaPosilkuText.Text != ""&&Podsumowanie.Text!="")
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
                    AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
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
                        AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
                    }
                    AzureDB.closeConnection();
                    MessageBox.Show("Posiłek został prawidołowo dodany", "Posiłek", MessageBoxButton.OK, MessageBoxImage.Information);
                    Podsumowanie.Text = "";
                    ProduktID.Clear();
                    ProduktIlosc.Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Błąd: " + ex.Message, "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void NazwaPosilkuText_TextChanged(object sender, TextChangedEventArgs e)
        {
            NowyPosilek.Text = "Twoj nowy Posiłek: " + NazwaPosilkuText.Text;
        }
    }
}

using AplikacjaDietetyczna.Klasy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UserControlPropozycja.xaml
    /// </summary>
    public partial class UserControlPropozycja : UserControl
    {
        public ObservableCollection<ComboBoxItem> cbItems1 { get; set; }//potrzebne do uzupełniania comboboxow
        public ComboBoxItem SelectedcbItem1 { get; set; }//potrzebne do uzupełniania comboboxow
        string IDUzytkownika = FunkcjeGlobalne.ID;


        private void UzupelnijComboBox()//uzupelnia combobox produktow wszystkimi dostepnymi w bazie danych produktami
        {
            DataContext = this;
            cbItems1 = new ObservableCollection<ComboBoxItem>();
            var cbItem1 = new ComboBoxItem { Content = "Wybierz produkt" };
            SelectedcbItem1 = cbItem1;
            cbItems1.Add(cbItem1);
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Produkty Where ID_User=" + IDUzytkownika + " order by NazwaProduktu";
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
        public UserControlPropozycja()
        {
            InitializeComponent();
            UzupelnijComboBox();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControls.UserControlDodaj();
            GridMain.Children.Add(add);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NumberAndLettersValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z0-9 ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            if (KalorieText.Text == "" ||
            BialkaText.Text == "" ||
            TluszczeText.Text == "" ||
            WeglowodanyText.Text == "" ||
            SposobPodaniaText.Text == "" ||
            NazwaPosilkuText.Text == "")
            {
                MessageBox.Show("Prosze wypełnić wszystkie pola", "Dodawanie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    AzureDB.openConnection();
                    AzureDB.sql = "INSERT INTO Produkty (Kalorie,Bialka,Tluszcze,Weglowodany,Podanie,NazwaProduktu,Zatwierdzone,ID_User) VALUES (" + KalorieText.Text + "," + BialkaText.Text + "," + TluszczeText.Text + "," + WeglowodanyText.Text + ",'" + SposobPodaniaText.Text + "','" + NazwaPosilkuText.Text + "',0," + IDUzytkownika + ");";
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
                    AzureDB.closeConnection();
                    MessageBox.Show("Produkt został pozytywnie dodany do twojej listy", "Dodawanie", MessageBoxButton.OK, MessageBoxImage.Information);
                    KalorieText.Text = "";
                    BialkaText.Text = "";
                    TluszczeText.Text = "";
                    WeglowodanyText.Text = "";
                    SposobPodaniaText.Text = "";
                    NazwaPosilkuText.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy dodawaniu"
                                      + Environment.NewLine + "opis: " + ex.Message.ToString(), "Dodawanie"
                                      , MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ProduktCombo_DownClosed(object sender, EventArgs e)
        {
            if (ProduktCombo.SelectedIndex != 0)
            {
                AzureDB.openConnection();
                AzureDB.sql = "Select * from Produkty WHERE ID_Produktu=" + ((ComboBoxItem)ProduktCombo.SelectedItem).Tag.ToString() + "";
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                AzureDB.dt = new DataTable();
                AzureDB.da.Fill(AzureDB.dt);
                if (AzureDB.dt.Rows.Count > 0)
                {
                    SposobPodaniaText_Copy.Text = AzureDB.dt.Rows[0]["Podanie"].ToString();
                    KalorieText_Copy.Text = AzureDB.dt.Rows[0]["Kalorie"].ToString();
                    BialkaText_Copy.Text = AzureDB.dt.Rows[0]["Bialka"].ToString();
                    TluszczeText_Copy.Text = AzureDB.dt.Rows[0]["Tluszcze"].ToString();
                    WeglowodanyText_Copy.Text = AzureDB.dt.Rows[0]["Weglowodany"].ToString();
                }
                AzureDB.closeConnection();
            }
            else
            {
                SposobPodaniaText_Copy.Text = "";
                KalorieText_Copy.Text = "";
                BialkaText_Copy.Text = "";
                TluszczeText_Copy.Text = "";
                WeglowodanyText_Copy.Text = "";
            }
        }

        private void ZmienProdukt_Click(object sender, RoutedEventArgs e)
        {
            if (KalorieText_Copy.Text == "" ||
           BialkaText_Copy.Text == "" ||
           TluszczeText_Copy.Text == "" ||
           WeglowodanyText_Copy.Text == "" ||
           SposobPodaniaText_Copy.Text == "" ||
           ProduktCombo.SelectedIndex == 0)
            {
                MessageBox.Show("Prosze wypełnić wszystkie pola lub wybrać produkt", "Modyfikacja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    AzureDB.openConnection();
                    AzureDB.sql = "UPDATE Produkty " +
                        "SET Kalorie="+ KalorieText_Copy.Text + ", Bialka="+ BialkaText_Copy.Text + ", Tluszcze="+ TluszczeText_Copy.Text + ", Weglowodany="+ WeglowodanyText_Copy.Text + ", Podanie='"+ SposobPodaniaText_Copy.Text + "' " +
                        "WHERE ID_Produktu="+((ComboBoxItem)ProduktCombo.SelectedItem).Tag.ToString()+";";
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
                    AzureDB.closeConnection();
                    MessageBox.Show("Produkt został pozytywnie zmieniony", "Modyfikacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    KalorieText_Copy.Text = "";
                    BialkaText_Copy.Text = "";
                    TluszczeText_Copy.Text = "";
                    WeglowodanyText_Copy.Text = "";
                    SposobPodaniaText_Copy.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy modyfikacji"
                                      + Environment.NewLine + "opis: " + ex.Message.ToString(), "Dodawanie"
                                      , MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UsunProdukt_Click(object sender, RoutedEventArgs e)
        {
            if (ProduktCombo.SelectedIndex != 0)
            {
                try
                {
                    AzureDB.openConnection();
                    AzureDB.sql = "DELETE FROM Produkty WHERE ID_Produktu=" + ((ComboBoxItem)ProduktCombo.SelectedItem).Tag.ToString();
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                    AzureDB.cmd.ExecuteNonQuery();
                    AzureDB.closeConnection();
                    MessageBox.Show("Produkt usunięty pomyślnie", "Usuwanie", MessageBoxButton.OK, MessageBoxImage.Error);
                    KalorieText_Copy.Text = "";
                    BialkaText_Copy.Text = "";
                    TluszczeText_Copy.Text = "";
                    WeglowodanyText_Copy.Text = "";
                    SposobPodaniaText_Copy.Text = "";
                    ProduktCombo.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy Usuwaniu"
                                      + Environment.NewLine + "opis: " + ex.Message.ToString(), "Usuwanie"
                                      , MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano Produktu do usunięcia", "Usuwanie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

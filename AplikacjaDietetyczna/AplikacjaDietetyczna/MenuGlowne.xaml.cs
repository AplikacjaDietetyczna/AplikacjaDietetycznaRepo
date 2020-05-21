using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using AplikacjaDietetyczna.Klasy;
namespace AplikacjaDietetyczna
{
    /// <summary>
    /// Logika interakcji dla klasy MenuGlowne.xaml
    /// </summary>
    public partial class MenuGlowne : Window
    {
        DataGrid grid = null;//potrzebne do wyświetlana danych
        TextBox tekstsql;
        public MenuGlowne()
        {
            InitializeComponent();
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); }; //Wyłącza program
            UserControl usc = new UserControls.UserControlPosilki();
            GridMain.Children.Add(usc);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void PokazID_Loaded(object sender, RoutedEventArgs e)
        {
            PokazID.Text = "Witaj, " + FunkcjeGlobalne.Login;
            /*
            if(FunkcjeGlobalne.IsAdmin != "1")
            {
                Dodaj.IsEnabled = false;
                Dodaj.Opacity = 0;
                SQL.IsEnabled = false;
                SQL.Opacity = 0;
            }
            */

        }
        private void PokazAdmin_Loaded(object sender, RoutedEventArgs e)
        {
            if (FunkcjeGlobalne.IsAdmin == "1")
            {

                PokazAdmin.Text = "User jest adminem";
            }
        }
      
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Sql": //otwieranie query
                    TextBox tekstsql = new TextBox();
                    GridMain.Children.Add(tekstsql);
                    tekstsql.Name = "sqlzapytanie";
                    tekstsql.Text = "INSERT INTO [dbo].[Posilki] (Nazwa,Kalorie) VALUES('Nazwa', ilosc kalorii);";
                    tekstsql.TextWrapping = TextWrapping.Wrap;
                    tekstsql.KeyDown += Zatwierdz;
                    break;
                case "ItemPodsumowanie":
                    usc = new UserControls.UserControlPodsumowanie();
                    GridMain.Children.Add(usc);
                    break;
                case "Dodaj"://wyswietlanie wszystkich elementow z bazy danych niestety SubmitChanges tutaj nie zadziala
                    try
                    {
                        DataGrid grid = new DataGrid();
                        AzureDB.openConnection();
                        AzureDB.sql = "select * from Posilki";
                        AzureDB.cmd.CommandType = CommandType.Text;
                        AzureDB.cmd.CommandText = AzureDB.sql;
                        AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                        AzureDB.dt = new DataTable();
                        AzureDB.da.Fill(AzureDB.dt);
                        grid.ItemsSource = AzureDB.dt.DefaultView;
                        GridMain.Children.Add(grid);
                        AzureDB.closeConnection();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Błąd połaczenia", "Baza", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Kalkulator":
                    UserControl calc = new UserControls.UserControlKalkulkator();
                    GridMain.Children.Add(calc);
                    break;
                case "Posilki":
                    usc = new UserControls.UserControlPosilki();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    usc = new UserControls.UserControlPosilki();
                    GridMain.Children.Add(usc);
                    break;
            }
        }

        private void Zatwierdz(Object sender, KeyEventArgs e)//wykonywanie query za pomoca entera
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    TextBox txtbox1; //potrzebne by przenies text z elementu docelowego
                    txtbox1 = (TextBox)e.Source;
                    string zapytanie;
                    zapytanie = txtbox1.Text;
                    AzureDB.openConnection();
                    AzureDB.sql = zapytanie;
                    AzureDB.cmd.CommandType = CommandType.Text;
                    AzureDB.cmd.CommandText = AzureDB.sql;
                    AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
                    AzureDB.closeConnection();
                    MessageBox.Show("Komenda została wykonana poprawnie", "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
                    //czysci textboxa po poprawnym wykonaniu
                    TextBox tb = (TextBox)sender;
                    tb.Text = string.Empty;
                }
                catch (Exception)
                {
                    MessageBox.Show("Niepoprawne Query", "Edycja", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


    }
}
﻿using System;
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
        public MenuGlowne()
        {
            InitializeComponent();
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); }; //Wyłącza program
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void PokazID_Loaded(object sender, RoutedEventArgs e)
        {
            PokazID.Text = "ID zalogowanego usera to: " + FunkcjeGlobalne.ID;

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
                case "ItemPodsumowanie":
                    usc = new UserControls.UserControlPodsumowanie();
                    GridMain.Children.Add(usc);
                    break;
                case "Dodaj"://wyswietlanie wszystkich elementow z bazy danych niestety SubmitChanges tutaj nie zadziala
                    try
                    {
                        grid = new DataGrid();
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
                //case "Kalkulator":
                //    UserControl calcBMI = new UserControls.KalkulatorBMI();
                //    GridMain.Children.Add(usc);
                //    break;
                default:
                    break;
            }
        }

        private void Zatwierdz(object sender, RoutedEventArgs e)
        {
        }
    }
}
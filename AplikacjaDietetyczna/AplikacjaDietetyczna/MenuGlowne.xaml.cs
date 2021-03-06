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
            Singleton singleton = Singleton.Instance;
            if (singleton.CheckIfUserIsAdmin() != "1")
            {
                Dodaj.IsEnabled = false;
                Dodaj.Opacity = 0;
            }


        }
        private void PokazAdmin_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton singleton = Singleton.Instance;
           

            if (singleton.CheckIfUserIsAdmin() == "1")
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
                    UserControl sql = new UserControls.UserControlSQL();
                    GridMain.Children.Add(sql);
                    break;
                case "Kalkulator":
                    UserControl calc = new UserControls.UserControlKalkulkator();
                    GridMain.Children.Add(calc);
                    break;
                case "Posilki":
                    usc = new UserControls.UserControlPosilki();
                    GridMain.Children.Add(usc);
                    break;
                case "Dodaj_produkt":
                    usc = new UserControls.UserControlPropozycja();
                    GridMain.Children.Add(usc);
                    break;
                case "Historia_Wagi":
                    usc = new UserControls.UserControlWaga();
                    GridMain.Children.Add(usc);
                    break;

                default:
                    usc = new UserControls.UserControlPosilki();
                    GridMain.Children.Add(usc);
                    break;
            }
        }
        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UserControls.UserControlProfil();
            GridMain.Children.Add(usc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControl onas = new UserControls.UserControlONas();
            GridMain.Children.Add(onas);
        }

        private void Wyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow logowanie = new MainWindow();
            logowanie.Show();
            this.Close();
            FunkcjeZerowanie.ZerownaieFunkcji();
            
        }

        private void SQL_Click(object sender, RoutedEventArgs e)
        {
            UserControl SQL = new UserControls.UserControlSQL();
            GridMain.Children.Add(SQL);

        }


    }
}
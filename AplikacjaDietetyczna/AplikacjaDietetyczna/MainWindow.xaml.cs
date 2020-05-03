﻿using System;
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
using System.Data;
using System.Data.SqlClient;
using AplikacjaDietetyczna.Klasy;

namespace AplikacjaDietetyczna
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); }; //Wyłącza prog

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        //taki maly eksperyment oraz przyklad jak uzyc nowej klasy
        //przy wladowaniu okna wypelnia pola danymi do logowania cos w stylu "zapamietaj mnie"
        //jesli ktos bedzie chcial zrobic cos bez tej klasy ponizej ma connection stringa
        //SqlConnection conn = new SqlConnection("Server=tcp:aplikacjaserwer.database.windows.net,1433;Initial Catalog=aplikacjadb;Persist Security Info=False;User ID=aplikacjaadmin;Password=Aplikacjahaslo1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
                      AzureDB.openConnection();
                      AzureDB.sql = "select * from users";
                      AzureDB.cmd.CommandType = CommandType.Text;
                      AzureDB.cmd.CommandText = AzureDB.sql;
                      AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
                      AzureDB.dt = new DataTable();
                      AzureDB.da.Fill(AzureDB.dt);
                      if (AzureDB.dt.Rows.Count > 0)
                      {
                          TextBoxUser.Text = AzureDB.dt.Rows[0]["user_login"].ToString();
                          TextBoxPassword.Password = AzureDB.dt.Rows[0]["user_password"].ToString();
                      }
                      AzureDB.closeConnection();
                      */
                      
        }
    }
}

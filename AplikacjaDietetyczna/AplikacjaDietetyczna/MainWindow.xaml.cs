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
using AplikacjaDietetyczna;
using System.IO;

namespace AplikacjaDietetyczna
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    
     

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); }; //Wyłącza program
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


            if (File.Exists("./Login.txt"))
            {
                string loginRead = Read.ReadFromFile();
                TextBoxUser.Text = loginRead;
            }


            //Stare logowanie użytkownika Login    
            //String message = "Nie udało połączyć się z bazą danych"; //To trzeba zmienić na tekst wyświetlający się gdzieś na ekranie logowania
            ////To jest testowo, by się szybciej logować. Potem trzeba będzie to usunąć
            //try
            //{
            //    AzureDB.openConnection();
            //    AzureDB.sql = "select top 1 * from Users";
            //    AzureDB.cmd.CommandType = CommandType.Text;
            //    AzureDB.cmd.CommandText = AzureDB.sql;
            //    AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            //    AzureDB.dt = new DataTable();
            //    AzureDB.da.Fill(AzureDB.dt);
            //    if (AzureDB.dt.Rows.Count > 0)
            //    {
            //        TextBoxUser.Text = AzureDB.dt.Rows[0]["Login"].ToString();
            //        TextBoxPassword.Password = AzureDB.dt.Rows[0]["Password"].ToString();
            //    }
            //    AzureDB.closeConnection();





            //}
            //catch (Exception ex)
            //{

            //    message = ex.Message.ToString();
            //}



        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            String message = "Podano nieprawidłowe dane logowania!"; //To trzeba zmienić na tekst wyświetlający się gdzieś na ekranie logowania
            try
            {
                //zapisywanie loginu do pliku txt
                string login = Convert.ToString(TextBoxUser.Text);
                Write.WriteToFile(login);
                

                AzureDB.openConnection();

                AzureDB.sql = ("SELECT TOP 1 * FROM USERS INNER JOIN Waga ON Users.ID_User = Waga.ID_User where Login =  '"  + TextBoxUser.Text + "'  AND Password = '" + TextBoxPassword.Password + "' ORDER BY Waga desc");
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.rd = AzureDB.cmd.ExecuteReader();
                if (AzureDB.rd.Read())
                {
                    FunkcjeGlobalne.ID = AzureDB.rd["ID_User"].ToString();
                    FunkcjeGlobalne.Login = AzureDB.rd["Login"].ToString();
                    FunkcjeGlobalne.Wiek = AzureDB.rd["Wiek"].ToString();
                    FunkcjeGlobalne.Wzrost = AzureDB.rd["Wzrost"].ToString();
                    FunkcjeGlobalne.Waga = AzureDB.rd["Waga"].ToString();
                    FunkcjeGlobalne.Plec = AzureDB.rd["Plec"].ToString();
                    FunkcjeGlobalne.Email = AzureDB.rd["Email"].ToString();
                    FunkcjeGlobalne.Data = "0";
                    message = "1";
                }

                AzureDB.closeConnection();
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }
            if(message == "1")
            {
                MenuGlowne menuGlowne = new MenuGlowne();
                menuGlowne.Show();
                this.Close();
            }
            else
            MessageBox.Show(message, "Info");


        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {

                Rejestracja rejestracja = new Rejestracja();
                rejestracja.Show();
                this.Close();

        }
    }
}

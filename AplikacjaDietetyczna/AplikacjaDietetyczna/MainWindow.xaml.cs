using System;
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            String message = "Podano nieprawidłowe dane logowania!"; //To trzeba zmienić na tekst wyświetlający się gdzieś na ekranie logowania
            try
            {
                AzureDB.openConnection();

                AzureDB.sql = ("select ID_User from Users where Login =  '"  + TextBoxUser.Text + "'  AND Password = '" + TextBoxPassword.Password + "'");
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.rd = AzureDB.cmd.ExecuteReader();
                if (AzureDB.rd.Read())
                {
                    string ID = AzureDB.rd["ID_User"].ToString();
                    Console.WriteLine(ID); //Do testowania
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
    }
}

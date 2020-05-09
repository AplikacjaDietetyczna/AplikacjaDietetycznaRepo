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
using AplikacjaDietetyczna;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace AplikacjaDietetyczna
{
    /// <summary>
    /// Interaction logic for Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        public Rejestracja()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
        }
        private void Rejestracja_Click(object sender, RoutedEventArgs e)
        {
            //regex sprawdzajacy poprawność maila
            string email = EMail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            //sprawdzanie czy dany uzytkownik juz jest w bazie (nie zwraca uwagi na duże litery i mozliwe ze trzeba bedzie to zmienic)
            AzureDB.openConnection();
            AzureDB.sql = "select top 1 * from Users where Login='"+TextBoxUser.Text+"'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);

            if (AzureDB.dt.Rows.Count == 0)//jesli takiego jeszcze nie ma
            {

                if (TextBoxPassword.Password == TextBoxPassword2.Password&& TextBoxPassword.Password.Length>7)//sprawdza wymogi do hasla
                {
                    if (match.Success)//sprawdza regexa do maila(jesli uzytkownika nie ma, haslo jest dobre)
                    {
                        try//dodawanie uzytkownika do bazy
                        {
                            AzureDB.openConnection();
                            //AzureDB.sql = "INSERT INTO Users (Login, Password, Email, Wiek, Wzrost, Plec) VALUES ('" + TextBoxUser.Text + "', '" + TextBoxPassword.Password + "', '" + EMail.Text + "', "+Wiek.Text+", "+Wzrost.Text+", '"+Plec.Text+"')";
                            AzureDB.cmd.CommandType = CommandType.Text;
                            AzureDB.cmd.CommandText = AzureDB.sql;
                            AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
                            AzureDB.closeConnection();
                            MessageBox.Show("Użytkownik " + TextBoxUser.Text + " został poprawnie utworzony.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        catch (Exception ex)//jesli baza nie dziala
                        {
                            MessageBox.Show("Błąd przy rejestracji"
                               + Environment.NewLine + "opis: " + ex.Message.ToString(), "Rejestracja"
                               , MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Niepoprawny adres E-mail", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Hasła nie są takie same lub jest ono za krótkie(min 8 znaków)", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Podany użytkownik just istnieje", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AzureDB.closeConnection();



        }
        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
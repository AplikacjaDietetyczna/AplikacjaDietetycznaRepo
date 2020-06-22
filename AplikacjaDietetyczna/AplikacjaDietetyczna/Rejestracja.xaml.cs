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
            PreviewKeyDown += (s, e) => {
                if (e.Key == Key.Escape)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }

            }; //Wyłącza program
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
            string UserID = "b";
            string Haslo = TextBoxPassword.Password;
            string Login = TextBoxUser.Text;
            string Plec = "M";

            if (PlecMezczyzna.IsChecked == true)
            {
                Plec = "M";
            }
            if (PlecKobieta.IsChecked == true)
            {
                Plec = "K";
            }
            //regex sprawdzajacy poprawność maila
            string email = EMail.Text;
            Regex regexEmail = new Regex(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex());
            Match emailMatch = regexEmail.Match(email);
            Regex wysokosc = new Regex(@"\d{2,3}");
            Regex login = new Regex(@"^(?=.{5,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
            Regex wiek = new Regex(@"\d{2}");
            Regex waga = new Regex(@"\d{2}");
            Match wiekMatch = wiek.Match(Wiek.Text);
            Match wysokoscMatch = wysokosc.Match(Wzrost.Text);
            Match wagaMatch = waga.Match(Waga.Text);
            Match loginMatch = login.Match(TextBoxUser.Text);
            //sprawdzanie czy dany uzytkownik juz jest w bazie (nie zwraca uwagi na duże litery i mozliwe ze trzeba bedzie to zmienic)
            AzureDB.openConnection();
            AzureDB.sql = "select top 1 * from Users where Login='" + TextBoxUser.Text + "'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);

            if (AzureDB.dt.Rows.Count == 0)//jesli takiego jeszcze nie ma
            {
              if (wagaMatch.Success)
                {
                if (wiekMatch.Success)
                {

                  if (loginMatch.Success)
                {

                    if (wysokoscMatch.Success)
                    {
                        if (TextBoxPassword.Password == TextBoxPassword2.Password && TextBoxPassword.Password.Length > 7)//sprawdza wymogi do hasla
                        {
                            if (emailMatch.Success)//sprawdza regexa do maila(jesli uzytkownika nie ma, haslo jest dobre)
                            {
                                try//dodawanie uzytkownika do bazy
                                {
                                    DateTime dateTime = DateTime.Now;
                                    string sqlFormattedDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    AzureDB.openConnection();
                                    AzureDB.sql = "INSERT INTO Users (Login, Password, Email, Wiek, Wzrost, Plec) VALUES ('" + TextBoxUser.Text + "', '" + TextBoxPassword.Password + "', '" + EMail.Text + "', " + Wiek.Text + ", " + Wzrost.Text + ", '" + Plec + "')";
                                    AzureDB.cmd.CommandType = CommandType.Text;
                                    AzureDB.cmd.CommandText = AzureDB.sql;
                                    AzureDB.cmd.ExecuteNonQuery(); //to wykonuje inserta :P
                                    AzureDB.closeConnection();
                                    //Insert do wagi, która zawiera informację o aktualnej dacie

                                    //Pobranie ID dopiero co dodanego Usera
                                    AzureDB.openConnection();
                                    AzureDB.sql = "SELECT top 1 ID_User FROM Users WHERE Login='" + Login + "' AND Password='" + Haslo + "'";
                                    AzureDB.cmd.CommandText = AzureDB.sql;
                                    AzureDB.rd = AzureDB.cmd.ExecuteReader();
                                    if (AzureDB.rd.Read())
                                    {
                                        UserID = AzureDB.rd["ID_User"].ToString();
                                        Console.WriteLine(UserID); //Do testowania
                                    }
                                    AzureDB.closeConnection(); //Nie mam pojęcia czy za każdym razem trzeba zamykać połączenie czy da się to zrobić jakoś mądrzej
                                                               //Dodanie wagi dla tego Usera
                                    AzureDB.openConnection();
                                    AzureDB.sql = "INSERT INTO Waga (ID_User, Waga, Data) VALUES ('" + UserID + "', '" + Waga.Text + "', '" + sqlFormattedDate + "')";
                                    AzureDB.cmd.CommandType = CommandType.Text;
                                    AzureDB.cmd.CommandText = AzureDB.sql;
                                    AzureDB.cmd.ExecuteNonQuery();

                                    AzureDB.closeConnection();
                                    MessageBox.Show("Użytkownik " + TextBoxUser.Text + " został poprawnie utworzony.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                catch (Exception ex)//jesli baza nie dziala
                                {
                                    MessageBox.Show("Błąd przy rejestracji"
                                       + Environment.NewLine + "opis: " + ex.Message.ToString(), "Rejestracja"
                                       , MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                finally
                                {
                                    MainWindow mainWindow = new MainWindow();
                                    mainWindow.Show();
                                    this.Close();
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
                        MessageBox.Show("Wzrost powinien być liczbą maksymalnie trzycyfrową", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Login powinien składać się z przynajmniej 5 do 20 znaków", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                }

                else
                {
                    MessageBox.Show("Wiek powinien być liczbą dwucyfrową", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

                else
                {
                    MessageBox.Show("Waga powinna być liczbą przynajmniej dwucyfrową", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


            else
            {
                MessageBox.Show("Podany użytkownik just istnieje", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }
        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


    }
}
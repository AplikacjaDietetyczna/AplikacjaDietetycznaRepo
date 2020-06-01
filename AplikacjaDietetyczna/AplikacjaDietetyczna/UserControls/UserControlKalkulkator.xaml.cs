using AplikacjaDietetyczna.Klasy;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AplikacjaDietetyczna;
using System.Data.SqlClient;
using System.Data;

namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy UserControlKalkulkator.xaml
    /// </summary>
    public partial class UserControlKalkulkator : UserControl
    {
        Type t = typeof(string);
        public UserControlKalkulkator()
        {
            InitializeComponent();
        }

        private void policzBMI_Click(object sender, RoutedEventArgs e)
        {
            
            Regex wagaRegex = new Regex(@"^[0-9]*$");
            Match wagaMatch = wagaRegex.Match(waga.Text);
            Regex wzrostRegex = new Regex(@"^[0-9]*$");
            Match wzrostMatch = wzrostRegex.Match(wzrost.Text);
            if ( wagaMatch.Success || wzrostMatch.Success)
            {
                float Waga = float.Parse(waga.Text);
                float Wzrost = float.Parse(wzrost.Text);
                float Wynik = Waga / ((Wzrost / 10000) * Wzrost);
                wynik.Text = Convert.ToString(Wynik);
                poleError.Text = "";
                if(Wynik < 18.5)
                {
                    niedowaga.Background = Brushes.Red;
                }
                else
                {
                    niedowaga.Background = Brushes.Transparent;
                }
                if (Wynik >= 18.5 && Wynik < 24.9)
                {
                    norma.Background = Brushes.Green;
                }
                else
                {
                    norma.Background = Brushes.Transparent;
                }
                if (Wynik >= 25.0 && Wynik < 29.9)
                {
                    nadwaga.Background = Brushes.Red;
                }
                else
                {
                    nadwaga.Background = Brushes.Transparent;
                }
                if (Wynik >= 30 && Wynik < 34.9)
                {
                    otyloscI.Background = Brushes.Red;
                }
                else
                {
                    otyloscI.Background = Brushes.Transparent;
                }
                if (Wynik >= 35)
                {
                    otyloscII.Background = Brushes.Red;
                }
                else
                {
                    otyloscII.Background = Brushes.Transparent;
                }

            }
            else
            {
                poleError.Text = "Źle podana waga lub wzrost!";
                niedowaga.Background = Brushes.Transparent;
                norma.Background = Brushes.Transparent;
                nadwaga.Background = Brushes.Transparent;
                otyloscI.Background = Brushes.Transparent;
                otyloscII.Background = Brushes.Transparent;
            }

        }

        private void pobierzDane_Click(object sender, RoutedEventArgs e)
        {
            waga.Text = FunkcjeGlobalne.Waga;
            wzrost.Text = FunkcjeGlobalne.Wzrost;

        }
    }
}

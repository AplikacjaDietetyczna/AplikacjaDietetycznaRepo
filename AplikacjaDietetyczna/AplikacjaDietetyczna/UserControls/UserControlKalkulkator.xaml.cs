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
            }
            else
            {
                poleError.Text = "Źle podana waga lub wzrost!";
            }

            //float Waga = float.Parse(waga.Text);
            //float Wzrost = float.Parse(wzrost.Text);
            //float Wynik = Waga / ((Wzrost / 10000) * Wzrost);
            //wynik.Text = Convert.ToString(Wynik);
        }
    }
}

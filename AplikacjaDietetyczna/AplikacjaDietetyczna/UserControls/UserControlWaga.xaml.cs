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

namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy UserControlWaga.xaml
    /// </summary>
    public partial class UserControlWaga : UserControl
    {
        public UserControlWaga()
        {
            InitializeComponent();
        }

        private void Click_Wroc(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlProfil();
            GridMain.Children.Add(add);
        }

        private void Click_ZmianaWaga(object sender, RoutedEventArgs e)
        {
            UserControl add = new UserControlProfil();
            GridMain.Children.Add(add);
        }
    }
}

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
    }
}
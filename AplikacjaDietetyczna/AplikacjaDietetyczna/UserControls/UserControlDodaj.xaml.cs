using AplikacjaDietetyczna.Klasy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikacjaDietetyczna.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlDodaj.xaml
    /// </summary>
    public partial class UserControlDodaj : UserControl
    {
        public ObservableCollection<ComboBoxItem> cbItems1 { get; set; }//potrzebne do uzupełniania comboboxow
        public ComboBoxItem SelectedcbItem1 { get; set; }//potrzebne do uzupełniania comboboxow
        private void UzupelnijComboBoxy()
        {
            DataContext = this;
            cbItems1 = new ObservableCollection<ComboBoxItem>();
            var cbItem1 = new ComboBoxItem { Content = "Wybierz produkt" };
            SelectedcbItem1 = cbItem1;
            cbItems1.Add(cbItem1);
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Produkty";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            foreach (DataRow dataRow in AzureDB.dt.Rows)
            {
                cbItems1.Add(new ComboBoxItem { Content = dataRow["NazwaProduktu"].ToString() });
            }
            AzureDB.closeConnection();

        }
        public UserControlDodaj()
        {
            InitializeComponent();
            UzupelnijComboBoxy();
        }
    }
}

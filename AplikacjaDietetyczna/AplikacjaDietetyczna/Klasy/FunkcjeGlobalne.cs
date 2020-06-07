using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDietetyczna.Klasy
{
   public class FunkcjeGlobalne
    {
        public static string ID { get; set; }
        public static string IsAdmin { get; set; }
        public static string Plec { get; set; }
        public static string Wiek { get; set; }
        public static string Wzrost { get; set; }
        public static string Waga { get; set; }
        public static string Login { get; set; }

        public static string NazwaPosilku { get; set; }

        public static string Data { get; set; }

        public static int CurrentDate { get; set; }

        public static string SelectedDate { get; set; }

        public static int SelectedPosilek { get; set; }
    }

}

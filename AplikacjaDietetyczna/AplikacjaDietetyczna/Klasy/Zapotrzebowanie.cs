using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDietetyczna.Klasy
{
    public class Zapotrzebowanie
    {


        public static double GetZapotrzebowanie()
        {
            //Harris-Benedict
            //Mężczyźni: 66.5 + (13.75 * waga) + (5.003 * wzrost) - (6.775 * wiek) Kobiety: 655.1 + (9.563 * waga) + (1.85 * wzrost)-(4.676 * wiek)
            double DzienneZapotrzebowanie = 0;
            if (FunkcjeGlobalne.Plec == "M")
            {
                DzienneZapotrzebowanie = 66.5 + (13.75 * Convert.ToDouble(FunkcjeGlobalne.Waga)) + (5.003 * Convert.ToDouble(FunkcjeGlobalne.Wzrost)) - (6.775 * Convert.ToDouble(FunkcjeGlobalne.Wiek));
            }
            else
            {
                DzienneZapotrzebowanie = 655.1 + (9.563 * Convert.ToDouble(FunkcjeGlobalne.Waga)) + (1.85 * Convert.ToDouble(FunkcjeGlobalne.Wzrost)) - (4.676 * Convert.ToDouble(FunkcjeGlobalne.Wiek));
            }

            return DzienneZapotrzebowanie;

        }




        //Do drugiego miejsca po przecinku

        public static double GetBialka ()
            {
          double Bialka = Math.Round((Double)Zapotrzebowanie.GetZapotrzebowanie() * 0.15, 2);
            return Bialka;
        }

        public static double GetKalorie()
        {
            double Kalorie = Math.Round((Double)GetZapotrzebowanie(), 2);
            return Kalorie;
        }

        public static double GetTluszcze()
        {
            double Tluszcze = Math.Round((Double)GetZapotrzebowanie() * 0.30, 2);
            return Tluszcze;
        }

        public static double GetWeglowodany()
        {
            double Weglowodany = Math.Round((Double)GetZapotrzebowanie() * 0.55, 2);
            return Weglowodany;
        }


        
        
       
      



    }
}

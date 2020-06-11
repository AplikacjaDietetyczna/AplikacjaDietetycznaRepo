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



    }
}

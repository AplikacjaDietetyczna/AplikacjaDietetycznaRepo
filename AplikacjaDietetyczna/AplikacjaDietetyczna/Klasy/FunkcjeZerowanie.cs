using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDietetyczna.Klasy
{
    public class FunkcjeZerowanie
    {
        public static void ZerownaieFunkcji()
        {
            FunkcjeGlobalne.ID = "";
            FunkcjeGlobalne.Plec = "";
            FunkcjeGlobalne.Wiek = "";
            FunkcjeGlobalne.Wzrost = "";
            FunkcjeGlobalne.Waga = "";
            //FunkcjeGlobalne.Login = "";
            FunkcjeGlobalne.Email = "";

        }

    }
}

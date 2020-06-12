using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDietetyczna.Klasy
{
    class Write
    {
        public static void WriteToFile(string login)
        {
            System.IO.File.WriteAllText("./Login.txt", login);
        }
    }
}

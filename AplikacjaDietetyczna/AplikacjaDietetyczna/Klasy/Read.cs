﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDietetyczna.Klasy
{
    class Read
    {
        public static string ReadFromFile()
        {
            string loginRead = System.IO.File.ReadAllText(@"C:\Users\Public\AplikacjaDietetyczna\Login.txt");

            return loginRead;
        }
    }
}
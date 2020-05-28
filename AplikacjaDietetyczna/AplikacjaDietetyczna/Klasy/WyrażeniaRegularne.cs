using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace AplikacjaDietetyczna.Klasy
{
  public  class WyrażeniaRegularne
    {

        
        public static string EmailRegex()
        {
        
            string wyrazenie = @"^([\w\.\-]{3,64})@([\w\-]{1,253})((\.(\w){2,3})+)$";


            return wyrazenie;


        }





    }
}

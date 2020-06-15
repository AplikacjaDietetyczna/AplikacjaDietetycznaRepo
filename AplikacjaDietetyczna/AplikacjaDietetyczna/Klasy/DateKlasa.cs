using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDietetyczna.Klasy
{
  public class DateKlasa
    {
        public static DateTime GetDate(int n)
        {

            DateTime dateTime = DateTime.Now.AddDays(n);
            return dateTime;
        }

        public static int GetCalendarDate(DateTime PodanaData)
        {
            int IleDni = 0;
            DateTime dateTime = DateTime.Now;
            var dateWithoutTime = dateTime.Date;

            while (PodanaData != dateWithoutTime)
            {
              PodanaData =  PodanaData.AddDays(1);
                IleDni++;
            }

            return IleDni;

        }




    }
}

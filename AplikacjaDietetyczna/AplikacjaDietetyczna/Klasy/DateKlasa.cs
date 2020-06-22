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
            try
            {
                DateTime dateTime = DateTime.Now;
                var dateWithoutTime = dateTime.Date;
                var PodanaDataWithoutTime = PodanaData.Date;
                Console.WriteLine(dateWithoutTime);
                Console.WriteLine(PodanaData);
                if (PodanaDataWithoutTime != dateWithoutTime)
                {
                    while (PodanaDataWithoutTime != dateWithoutTime)
                    {
                        PodanaDataWithoutTime = PodanaDataWithoutTime.AddDays(1);
                        IleDni++;
                    }
                }

                else
                {
                    IleDni = 0;
                }
            }

            catch
            {

            }


            return IleDni;

        }




    }
}

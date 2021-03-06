﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplikacjaDietetyczna.Klasy;

namespace AplikacjaDietetyczna.Klasy
{
    class Dekorator
    {

        public abstract class Posilek
        {
            public abstract double Calculate(double IloscKalorie, double Ilosc);

            //public abstract double CalculateBialka();
            //public abstract double CalculateTluszcze();
            //public abstract double CalculateWeglowodany(double IloscWeglowodany, double Ilosc);
            public abstract string GetName(string Produkty, int Ilosc, string Podanie);

            public abstract string GetFullName(string PosilekNazwa, string Produkty);
        }

        public class TypPosilku : Posilek
        {
            public override string GetName(string Produkty, int Ilosc, string Podanie)
            {
               return "";
               
            }
            public override string GetFullName(string PosilekNazwa, string Produkty)
            {
                if (PosilekNazwa != "")
                {
                    return PosilekNazwa + ": ";
                }
                else return "";
            }

            public override double Calculate(double IloscKalorie, double Ilosc)
            {
                return 0;
            }

            //public override double CalculateBialka()
            //{
            //    return 0;
            //}

            //public override double CalculateTluszcze()
            //{
            //    return 0;
            //}

            //public override double CalculateWeglowodany(double IloscWeglowodany, double Ilosc)
            //{
            //    return 0;
            //}





        }

        public class PosilekDekorator : Posilek
        {
            protected Posilek _posilek;

            public PosilekDekorator(Posilek posilek)
            {
                _posilek = posilek;
            }

            public override string GetName(string Produkty, int Ilosc, string Podanie)
            {
                return _posilek.GetName(Produkty, Ilosc, Podanie);
            }
            public override string GetFullName(string PosilekNazwa, string Produkty)
            {
                return _posilek.GetFullName(PosilekNazwa, Produkty);
            }
            public override double Calculate(double IloscKalorie, double Ilosc)
            {
                return _posilek.Calculate(IloscKalorie,Ilosc);
            }

            //public override double CalculateBialka()
            //{
            //    return _posilek.CalculateBialka();
            //}

            //public override double CalculateTluszcze()
            //{
            //    return _posilek.CalculateTluszcze();
            //}

            //public override double CalculateWeglowodany(double IloscWeglowodany, double Ilosc)
            //{
            //    return _posilek.CalculateWeglowodany(IloscWeglowodany);
            //}

         }

        public class ProduktDekorator : PosilekDekorator
        {

            public ProduktDekorator(Posilek posilek) : base(posilek)
            {

            }

            public override double Calculate(double IloscKalorie, double Ilosc)
            {
                return base.Calculate(IloscKalorie, Ilosc) + IloscKalorie * Ilosc;
            }
            //public override double CalculateBialka(double IloscBialka)
            //{
            //    return base.CalculateBialka() + IloscBialka;
            //}

            //public override double CalculateTluszcze(double IloscTluszcze)
            //{
            //    return base.CalculateTluszcze() + IloscTluszcze;
            //}

            public override string GetName( string Produkty, int Ilosc, string Podanie)
            {
                if (Ilosc == 0)
                {
                    return "";
                }

                if(Ilosc == 1)
                {
                    return base.GetName(Produkty, Ilosc, Podanie) +Podanie +" "+ Produkty;
                }
                else
                    return base.GetName(Produkty, Ilosc, Podanie) + Ilosc + " x " + Podanie +" "+Produkty;
            }

            public override string GetFullName(string PosilekNazwa, string Produkty)
            {
                return base.GetFullName(PosilekNazwa, Produkty) + Produkty;
            }


            //public override double CalculateWeglowodany(double IloscWeglowodany, double Ilosc)
            //{
            //    return base.CalculateWeglowodany(IloscWeglowodany) + IloscWeglowodany;
            //}


        }





    }
}

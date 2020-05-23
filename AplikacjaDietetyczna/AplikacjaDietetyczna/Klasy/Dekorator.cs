using System;
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
            //public abstract double CalculateKalorie();

            //public abstract double CalculateBialka();
            //public abstract double CalculateTluszcze();
            public abstract double CalculateWeglowodany(double IloscWeglowodany);
            public abstract string GetName(string PosilekNazwa);

        }

        public class TypPosilku : Posilek
        {
            public override string GetName(string PosilekNazwa)
            {
                return PosilekNazwa;
            }

            //public override double CalculateKalorie()
            //{
            //    return 0;
            //}

            //public override double CalculateBialka()
            //{
            //    return 0;
            //}

            //public override double CalculateTluszcze()
            //{
            //    return 0;
            //}

            public override double CalculateWeglowodany(double IloscWeglowodany)
            {
                return 0;
            }





        }

        public class PosilekDekorator : Posilek
        {
            protected Posilek _posilek;

            public PosilekDekorator(Posilek posilek)
            {
                _posilek = posilek;
            }

            public override string GetName(string PosilekNazwa)
            {
                return _posilek.GetName(PosilekNazwa);
            }

            //public override double CalculateKalorie()
            //{
            //    return _posilek.CalculateKalorie();
            //}

            //public override double CalculateBialka()
            //{
            //    return _posilek.CalculateBialka();
            //}

            //public override double CalculateTluszcze()
            //{
            //    return _posilek.CalculateTluszcze();
            //}

            public override double CalculateWeglowodany(double IloscWeglowodany)
            {
                return _posilek.CalculateWeglowodany(IloscWeglowodany);
            }

         }

        public class ProduktDekorator : PosilekDekorator
        {

            public ProduktDekorator(Posilek posilek) : base(posilek)
            {

            }

            //public override double CalculateKalorie(double IloscKalorie)
            //{
            //    return base.CalculateKalorie() + IloscKalorie;
            //}
            //public override double CalculateBialka(double IloscBialka)
            //{
            //    return base.CalculateBialka() + IloscBialka;
            //}

            //public override double CalculateTluszcze(double IloscTluszcze)
            //{
            //    return base.CalculateTluszcze() + IloscTluszcze;
            //}

            public override double CalculateWeglowodany(double IloscWeglowodany)
            {
                return base.CalculateWeglowodany(IloscWeglowodany) + IloscWeglowodany;
            }


        }





    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AplikacjaDietetyczna.Klasy;
using NUnit.Framework;

namespace AplikacjaDietetyczna.UnitTests
{
    class UnitTest4
    {
        [SetUp]

        [Test]
        public void Test4()
        {
            Assert.AreEqual("Chipsy", AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzNazweProduktu(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu("Chipsy")));
            Assert.AreNotEqual("Chleb przenny", AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzNazweProduktu(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu("Chleb Przenny")));
            Assert.AreNotEqual("Jajko kurze", AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzNazweProduktu(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu("jajko kurze")));
            Assert.AreEqual("Czekolada Mleczna", AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzNazweProduktu(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu("Czekolada Mleczna")));
        }
    }
}

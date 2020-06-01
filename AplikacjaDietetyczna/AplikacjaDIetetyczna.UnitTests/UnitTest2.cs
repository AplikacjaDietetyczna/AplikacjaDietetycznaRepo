using NUnit.Framework;
using AplikacjaDIetetyczna;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace AplikacjaDIetetyczna.UnitTests
{
    public class TestyJednostkowe2
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PobieranieDanychTest()
        {
            Assert.AreEqual("Banan", AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzNazweProduktu(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu("Banan")));
            Assert.AreEqual(7, AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzNazweProduktu(7)));
            Assert.AreNotEqual("Chleb Przenny", AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzNazweProduktu(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu("Banan")));
            Assert.AreNotEqual(6, AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzNazweProduktu(7)));

        }


    }
}
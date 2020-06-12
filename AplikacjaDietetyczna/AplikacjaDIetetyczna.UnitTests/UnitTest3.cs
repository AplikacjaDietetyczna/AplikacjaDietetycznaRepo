using NUnit.Framework;
using AplikacjaDIetetyczna;
using AplikacjaDietetyczna.Klasy;
using System.Reflection;
using System;
using AplikacjaDietetyczna.UserControls;
using EO.Internal;

namespace AplikacjaDIetetyczna.UnitTests
{
    class TestyJednostkowe3
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void PobieranieWagiTest()
        {
            var obj = new PobieranieDanych();
            Assert.IsInstanceOf<int>(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzWage(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIdProduktu()));
        }
    }
}

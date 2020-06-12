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
            Assert.That("11", Does.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.WeightRegex()));
            Assert.That("11asd", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.WeightRegex()));


            // Assert.IsInstanceOf<int>(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzWage(AplikacjaDietetyczna.Klasy.PobieranieDanych.PobierzIDUsera("29")));
        }

    }
}

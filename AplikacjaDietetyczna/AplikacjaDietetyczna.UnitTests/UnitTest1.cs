using NUnit.Framework;
using AplikacjaDIetetyczna;
namespace AplikacjaDIetetyczna.UnitTests
{
    public class TestyJednostkowe
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestowyTest()
        {

            string result = "abcdefg";

            Assert.That(result, Does.Match("a*g"));
            Assert.That(result, Does.Not.Match("m*n"));

        }
        [Test]
        public void EmailRegexTest()
        {

            string MaksEmail = "qwertyuiopasdfghjklqwertyuiopasdfghjklqwertyuiopadsdfghjklqwedd@gmailddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd.pld";
           AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex();
            
            
           Assert.That("pajfu@gmail.com", Does.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           Assert.That("pajfś@gmail.pl", Does.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           Assert.That("@gmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           Assert.That("apkagmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           Assert.That("apka@gmailpl", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           Assert.That("@gmail@gmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           Assert.That("Drop table produkty@gmail.com", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           //Minimum trzy litery przed @
           Assert.That("pa@gmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           Assert.That("paj@gmail.pl", Does.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
           //Według standardu są maksymalnie 64 znaki przed @
           Assert.That("qwertyuiopasdfghjklqwertyuiopasdfghjklqwertyuiopasdfghjklqweddd@gmail.pl", Does.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex())); //63 znaki
           Assert.That("qwertyuiopasdfghjklqwertyuiopasdfghjklqwertyuiopadsdfghjklqwedddd@gmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex())); //64 znaki
           Assert.That("małpa@@małpa.małpa", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex())); //2 x @
           Assert.That(MaksEmail, Does.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex())); //maksymalnie 255 znaków po @
           Assert.That(MaksEmail+"a", Does.Not.Match(AplikacjaDietetyczna.Klasy.WyrażeniaRegularne.EmailRegex()));
        }


    }
}
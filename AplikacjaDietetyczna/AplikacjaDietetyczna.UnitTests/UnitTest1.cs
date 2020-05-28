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
            AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex();
            
            
           Assert.That("pajfu@gmail.com", Does.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           Assert.That("pajfœ@gmail.pl", Does.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           Assert.That("@gmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           Assert.That("apkagmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           Assert.That("apka@gmailpl", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           Assert.That("@gmail@gmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           Assert.That("Drop table produkty@gmail.com", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           //Minimum trzy litery przed @
           Assert.That("pa@gmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           Assert.That("paj@gmail.pl", Does.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
           //Wed³ug standardu s¹ maksymalnie 64 znaki przed @
           Assert.That("qwertyuiopasdfghjklqwertyuiopasdfghjklqwertyuiopasdfghjklqweddd@gmail.pl", Does.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex())); //63 znaki
           Assert.That("qwertyuiopasdfghjklqwertyuiopasdfghjklqwertyuiopadsdfghjklqwedddd@gmail.pl", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex())); //64 znaki
           Assert.That("ma³pa@@ma³pa.ma³pa", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex())); //2 x @
           Assert.That(MaksEmail, Does.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex())); //maksymalnie 255 znaków po @
           Assert.That(MaksEmail+"a", Does.Not.Match(AplikacjaDietetyczna.Klasy.Wyra¿eniaRegularne.EmailRegex()));
        }


    }
}
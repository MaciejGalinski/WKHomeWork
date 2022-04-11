using System;
using NUnit.Framework;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;

namespace WKHomeWork.Test.TestPracownik
{
    public class Test_PracownikNazwisko
    {
        [Test]
        public void Test_PracownikNazwisko_Poprawne()
        {
            var nazwisko1 = new PracownikNazwisko("Galiński");
            Assert.AreEqual("Galiński", nazwisko1.Value);
            
            
            var nazwisko2 = new PracownikNazwisko(" Galiński ");
            Assert.AreEqual("Galiński", nazwisko2.Value);
        }
        
        [Test]
        public void Test_PracownikNazwisko_PorównanieNazwisk()
        {
            var nazwisko1 = new PracownikNazwisko("Galiński");
            var nazwisko2 = new PracownikNazwisko("Galiński");

            Assert.IsTrue(nazwisko1.Equals(nazwisko2));
        }

        [Test]
        public void Test_PracownikNazwisko_Null()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var pracownikNazwisko = new PracownikNazwisko(null);
                });
        }
        
        [Test]
        public void Test_PracownikNazwisko_PustaWartosc()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var pracownikNazwisko = new PracownikNazwisko("");
                });
        }
        
        [Test]
        public void Test_PracownikNazwisko_WartoscPowyzejIlosciZnakow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    var pracownikNazwisko = new PracownikNazwisko("Naplotkowała sosna, że już się zbliża wiosna. Kret skrzywił się ponuro: Przyjedzie pewnie furą. Jeż się najeżył srodze: Raczej...");
                });
        }
    }
}
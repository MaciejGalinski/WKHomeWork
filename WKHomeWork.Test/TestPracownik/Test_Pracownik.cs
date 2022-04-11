using System;
using NUnit.Framework;
using WKHomeWork.Library.Domain.PracownikAggregate;
using WKHomeWork.Library.Domain.PracownikAggregate.Enums;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;

namespace WKHomeWork.Test.TestPracownik
{
    public class Test_Pracownik
    {
        [Test]
        public void Test_Pracownik_Poprawny()
        {
            // arrange

            var pracownikNazwisko = new PracownikNazwisko("Galiński");
            var pracownikNumerEwidencyjny = new PracownikNumerEwidencyjny("6");
            var pracownikPlec = new PracownikPlec(PracownikPlecEnum.Extraterrestial);

            // act
            var pracownik = new Pracownik(pracownikNumerEwidencyjny, pracownikNazwisko, pracownikPlec);

            // assert
            
            Assert.IsTrue(pracownik.NumerEwidencyjny != null && pracownik.NumerEwidencyjny.Equals(pracownikNumerEwidencyjny));
            Assert.IsTrue(pracownik.Nazwisko != null && pracownik.Nazwisko.Equals(pracownikNazwisko));
            Assert.IsTrue(pracownik.Plec != null && pracownik.Plec.Equals(pracownikPlec));
        }
        
        [Test]
        public void Test_Pracownik_PusteObiekty()
        {
            // arrange

            var pracownikNazwisko = new PracownikNazwisko("Galiński");
            var pracownikNumerEwidencyjny = new PracownikNumerEwidencyjny("6");
            var pracownikPlec = new PracownikPlec(PracownikPlecEnum.Extraterrestial);

            // assert
            
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var pracownik = new Pracownik(
                        null, //pusty obiekt NumerReferencyjny
                        pracownikNazwisko,
                        pracownikPlec);
                }, ToString());
            
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var pracownik = new Pracownik(
                        pracownikNumerEwidencyjny,
                        null, //pusty obiekt Nazwisko
                        pracownikPlec);
                }, ToString());
            
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var pracownik = new Pracownik(
                        pracownikNumerEwidencyjny,
                        pracownikNazwisko,
                        null); //pusty obiekt Płeć
                }, ToString());
        }

        [Test]
        public void Test_Pracownik_ZmianaNazwiska()
        {
            // arrange
            
            var pracownik = new Pracownik(
                new PracownikNumerEwidencyjny("6"),
                new PracownikNazwisko("Galiński"),
                new PracownikPlec(PracownikPlecEnum.Extraterrestial));
            
            // act
            var noweNazwisko = new PracownikNazwisko("Brzęczyszczykiewicz");
            
            pracownik.SetNazwisko(noweNazwisko);
            
            // assert
            
            Assert.IsTrue(pracownik.Nazwisko.Equals(noweNazwisko));
        }
        
        [Test]
        public void Test_Pracownik_ZmianaPlci()
        {
            // arrange
            
            var pracownik = new Pracownik(
                new PracownikNumerEwidencyjny("6"),
                new PracownikNazwisko("Galiński"),
                new PracownikPlec(PracownikPlecEnum.Extraterrestial));
            
            // act
            var nowaPlec = new PracownikPlec(PracownikPlecEnum.TrudnoPowiedziec);
            
            pracownik.SetPlec(nowaPlec);
            
            // assert
            
            Assert.IsTrue(pracownik.Plec.Equals(nowaPlec));
        }
        
        [Test]
        public void Test_Pracownik_ZmianaNumeruEwidencyjnego()
        {
            // arrange
            
            var pracownik = new Pracownik(
                new PracownikNumerEwidencyjny("6"),
                new PracownikNazwisko("Galiński"),
                new PracownikPlec(PracownikPlecEnum.Extraterrestial));
            
            // act
            var nowyNumerEwidencyjny = new PracownikNumerEwidencyjny("9");
            
            pracownik.SetNumerEwidencyjny(nowyNumerEwidencyjny);
            
            // assert
            
            Assert.IsTrue(pracownik.NumerEwidencyjny.Equals(nowyNumerEwidencyjny));
        }
    }
}
using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;

namespace WKHomeWork.Test.TestPracownik
{
    public class Test_PracownikNumerEwidencyjny
    {
        [Test]
        public void Test_PracownikNumerEwidencyjny_Poprawne1()
        {
            var pracownikNumerEwidencyjnyValue = "1";
            var pracownikNumerEwidencyjnyCorrrectValue = "00000001";

            var pracownikNumerEwidencyjny = new PracownikNumerEwidencyjny(pracownikNumerEwidencyjnyValue);
            
            Assert.IsTrue(Regex.IsMatch(pracownikNumerEwidencyjnyValue,@"^\d{1,8}$"));
            
            Assert.AreEqual(pracownikNumerEwidencyjnyCorrrectValue, pracownikNumerEwidencyjny.Value);
        }
        
        [Test]
        public void Test_PracownikNumerEwidencyjny_Poprawne2()
        {
            var pracownikNumerEwidencyjnyValue = "10101";
            var pracownikNumerEwidencyjny = new PracownikNumerEwidencyjny(pracownikNumerEwidencyjnyValue);
            
            Assert.IsTrue(Regex.IsMatch(pracownikNumerEwidencyjnyValue,@"^\d{1,8}$"));
            
            Assert.AreEqual("00010101", pracownikNumerEwidencyjny.Value);
        }
        
        [Test]
        public void Test_PracownikNumerEwidencyjny_PustaWartosc()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var pracownikNumerEwidencyjny = new PracownikNumerEwidencyjny(null);
                });
        }
        
        [Test]
        public void Test_PracownikNumerEwidencyjny_WartoscPowyzejIlosciZnakow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    var pracownikNumerEwidencyjny = new PracownikNumerEwidencyjny("1234567890");
                });
        }
        
        [Test]
        public void Test_PracownikNumerEwidencyjny_NiepoprawnyTypZnakow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    var pracownikNumerEwidencyjny = new PracownikNumerEwidencyjny("abcdefh12");
                });
        }
    }
}
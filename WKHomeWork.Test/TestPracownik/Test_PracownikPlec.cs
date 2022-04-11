using System;
using NUnit.Framework;
using WKHomeWork.Library.Domain.PracownikAggregate.Enums;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;

namespace WKHomeWork.Test.TestPracownik
{
    public class Test_PracownikPlec
    {
        [Test]
        public void Test_PracownikPlec_Correct()
        {
            var plec = new PracownikPlec(PracownikPlecEnum.Extraterrestial);

            Assert.AreEqual(PracownikPlecEnum.Extraterrestial, plec.Value);
        }
        
        [Test]
        public void Test_PracownikPlec_CorrectFromString()
        {
            var plec = new PracownikPlec("extraterrestial");

            Assert.AreEqual(PracownikPlecEnum.Extraterrestial, plec.Value);
        }
        
        [Test]
        public void Test_PracownikPlec_InCorrectFromString()
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    var plec = new PracownikPlec("Kura");
                });
        }
    }
}
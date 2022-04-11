using System;
using Moq;
using NUnit.Framework;
using WKHomeWork.Library.Domain.PracownikAggregate.Entities;

namespace WKHomeWork.Test.TestPracownik
{
    public class Test_PracownikApi
    {
        [Test]
        public void Test_PracownikCreate_PoprawnyZApi()
        {
            var pracownikCreate = new PracownikCreate("Kopernik", "Kobieta");
            
            Assert.AreEqual("Kopernik", pracownikCreate.Nazwisko);
            Assert.AreEqual("Kobieta", pracownikCreate.Plec);
        }
        
        [Test]
        public void Test_PracownikUpdate_PoprawnyZApi()
        {
            var pracownikCreate = new PracownikUpdate("Kopernik", "Kobieta", "1234");
            
            Assert.AreEqual("Kopernik", pracownikCreate.Nazwisko);
            Assert.AreEqual("Kobieta", pracownikCreate.Plec);
            Assert.AreEqual("1234", pracownikCreate.NumerEwidencyjny);
        }
        
        
        [Test]
        public void Test_PracownikCreate_NiepoprawnyZApi()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikCreate("", "");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikCreate("Galiński", "");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikCreate("", "Kobieta");
            });
        }

        [Test]
        public void Test_PracownikUpdate_NiepoprawnyZApi()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikUpdate("", "", "");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikUpdate("Galiński", "", "");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikUpdate("", "Kobieta", "");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikUpdate("", "Kobieta", "8");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikUpdate("", "", "8");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikUpdate("Galiński", "Kobieta", "");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var pracownikCreate = new PracownikUpdate("Galiński", "", "8");
            });
        }
    }
}
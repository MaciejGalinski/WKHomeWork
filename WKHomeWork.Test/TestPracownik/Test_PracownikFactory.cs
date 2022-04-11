using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WKHomeWork.Library.Domain.PracownikAggregate;
using WKHomeWork.Library.Domain.PracownikAggregate.Entities;
using WKHomeWork.Library.Domain.PracownikAggregate.Services;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;

namespace WKHomeWork.Test.TestPracownik
{
    public class Test_PracownikFactory
    {
        private Mock<INextNumerEwidencyjnyService> _nextNumerEwidencyjnyService;
        private PracownikCreate _pracownikCreate;
        private PracownikUpdate _pracownikUpdate;

        [SetUp]
        public void TestSetup()
        {
            _nextNumerEwidencyjnyService = new Mock<INextNumerEwidencyjnyService>();
            _nextNumerEwidencyjnyService.Setup(p => p.Get())
                .ReturnsAsync(() => new PracownikNumerEwidencyjny("8"));

            _pracownikCreate = new PracownikCreate("Galiński", "extraterrestial");

            _pracownikUpdate = new PracownikUpdate("Galiński", "extraterrestial", "7");
        }
        
        [Test]
        public async Task Test_PracownikCreate_PoprawnyZApi()
        {
            var pracownikZCreate = await new PracownikFactory(_nextNumerEwidencyjnyService.Object).Get(_pracownikCreate);
            
            Assert.IsTrue(pracownikZCreate.Plec.Equals(new PracownikPlec(_pracownikCreate.Plec)));
            Assert.IsTrue(pracownikZCreate.Nazwisko.Equals(new PracownikNazwisko(_pracownikCreate.Nazwisko)));
            Assert.IsTrue(pracownikZCreate.NumerEwidencyjny.Equals(new PracownikNumerEwidencyjny("8")));
            
            _nextNumerEwidencyjnyService.Verify(s=>s.Get(), Times.Once);
        }
        
        [Test]
        public void Test_PracownikApi_Pusty()
        {
            Pracownik pracownikCreate = null;
            
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                pracownikCreate = await new PracownikFactory(_nextNumerEwidencyjnyService.Object).Get(null);
            });
        }
    }
}
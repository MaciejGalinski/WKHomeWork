using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WKHomeWork.Library.Domain.PracownikAggregate.Services;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;
using WKHomeWork.Library.Repository;

namespace WKHomeWork.Test.TestPracownik
{
    public class Test_PracownikNumerEwidencyjnyService
    {
        
        private Mock<IPracownikRepository> _pracownikRepository;
        
        [SetUp]
        public void TestSetup()
        {
            _pracownikRepository = new Mock<IPracownikRepository>();
            _pracownikRepository.Setup(p => 
                p.GetLastNumerEwidencyjny()).ReturnsAsync(() => 
                new PracownikNumerEwidencyjny("7"));
        }

        [Test]
        public async Task Test_PracownikNumerEwidencyjnyService_WezNastepny()
        {
            var nextNumerEwidencyjny =  new NextNumerEwidencyjnyService(_pracownikRepository.Object);

            var nowyNumer = await nextNumerEwidencyjny.Get();
            
            _pracownikRepository.Verify(s=>s.GetLastNumerEwidencyjny().Result, Times.Once);
            
            Assert.IsTrue(nowyNumer.Equals(new PracownikNumerEwidencyjny("8")));
        }
        
        [Test]
        public void Test_PracownikNumerEwidencyjnyService_PusteRepo()
        {
            Assert.Throws<ArgumentNullException>(() =>
                {
                    var nextNumerEwidencyjny = new NextNumerEwidencyjnyService(null);
                }
            );

        }
    }
}
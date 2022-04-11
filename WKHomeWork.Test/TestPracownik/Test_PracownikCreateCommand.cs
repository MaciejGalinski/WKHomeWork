using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WKHomeWork.Library.Domain.PracownikAggregate;
using WKHomeWork.Library.Domain.PracownikAggregate.Commands;
using WKHomeWork.Library.Domain.PracownikAggregate.Entities;
using WKHomeWork.Library.Domain.PracownikAggregate.Enums;
using WKHomeWork.Library.Domain.PracownikAggregate.Services;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;
using WKHomeWork.Library.Repository;

namespace WKHomeWork.Test.TestPracownik
{
    public class Test_PracownikCreateCommand
    {
        private Mock<IPracownikRepository> _pracownikRepository;
        private Mock<INextNumerEwidencyjnyService> _nextNumerEwidencyjnyService;
        private Mock<IPracownikFactory> _pracownikFactory;
        private PracownikCreate _pracownikCreate;
        private PracownikCreateHandler _pracownikCreateHandler;

        [SetUp]
        public void TestSetup()
        {
            _pracownikRepository = new Mock<IPracownikRepository>();
            _pracownikRepository.Setup(p => p.Insert(It.IsAny<Pracownik>()));

            _nextNumerEwidencyjnyService = new Mock<INextNumerEwidencyjnyService>();
            _nextNumerEwidencyjnyService.Setup(p => p.Get())
                .ReturnsAsync(() => new PracownikNumerEwidencyjny("7"));

            _pracownikCreate = new PracownikCreate("Galiński", "Mężczyzna");
            
            _pracownikFactory = new Mock<IPracownikFactory>();
            _pracownikFactory.Setup(p => p.Get(It.IsAny<PracownikCreate>()))
                .ReturnsAsync(() => new Pracownik(new PracownikNumerEwidencyjny("8"), 
                    new PracownikNazwisko("Galiński"), new PracownikPlec(PracownikPlecEnum.Mężczyzna)));
            
            _pracownikCreateHandler = new PracownikCreateHandler(_pracownikRepository.Object, _pracownikFactory.Object);
        }
        
        [Test]
        public async Task Test_PracownikInsert_Poprawny()
        {
            // act

            await _pracownikCreateHandler.Handle(_pracownikCreate);
            
            _pracownikFactory.Verify(s=> 
                s.Get(_pracownikCreate).Result, Times.Once);
            
            _pracownikRepository.Verify(s=> 
                s.Insert(_pracownikFactory.Object.Get(_pracownikCreate).Result), Times.Once);
          
            // assert
        }

        [Test]
        public void Test_PracownikInsert_PusteObiekty()
        {
            // assert
         
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                IPracownikCreateHandler pracownikCreateHandler 
                    = new PracownikCreateHandler(_pracownikRepository.Object, _pracownikFactory.Object);
                
                await pracownikCreateHandler.Handle(null);
            }, ToString());
            
            Assert.Throws<ArgumentNullException>(() =>
                {
                    IPracownikCreateHandler pracownikCreateHandler 
                        = new PracownikCreateHandler(null, _pracownikFactory.Object);
                    
                }, ToString());
            
            Assert.Throws<ArgumentNullException>(() =>
                {
                    IPracownikCreateHandler pracownikCreateHandler 
                        = new PracownikCreateHandler(_pracownikRepository.Object, null);
                }, ToString());
        }
    }
}
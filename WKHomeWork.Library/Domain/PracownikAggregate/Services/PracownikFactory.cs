using System;
using System.Threading.Tasks;
using WKHomeWork.Library.Domain.PracownikAggregate.Entities;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;

namespace WKHomeWork.Library.Domain.PracownikAggregate.Services
{
    public class PracownikFactory : IPracownikFactory
    {
        private readonly INextNumerEwidencyjnyService _nextNumerEwidencyjnyService;

        public PracownikFactory(INextNumerEwidencyjnyService nextNumerEwidencyjnyService)
        {
            _nextNumerEwidencyjnyService = nextNumerEwidencyjnyService;
        }
        
        public async Task<Pracownik> Get(PracownikCreate pracownikFromApi)
        {
            if (pracownikFromApi == null) throw new ArgumentNullException("Pusty obiekt 'pracownikFromApi");
            if (_nextNumerEwidencyjnyService == null) throw new ArgumentNullException("Pusty serwis 'nextNumerEwidencyjnyService");

            PracownikNumerEwidencyjny numerEwidencyjny = await _nextNumerEwidencyjnyService.Get();
            
            return new Pracownik(numerEwidencyjny
                , new PracownikNazwisko(pracownikFromApi.Nazwisko)
                , new PracownikPlec(pracownikFromApi.Plec));
        }
    }

    public interface IPracownikFactory
    {
        Task<Pracownik> Get(PracownikCreate pracownikFromApi);
    }
}
using System;
using System.Threading.Tasks;
using WKHomeWork.Library.Commands;
using WKHomeWork.Library.Domain.PracownikAggregate.Entities;
using WKHomeWork.Library.Domain.PracownikAggregate.Services;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;
using WKHomeWork.Library.Repository;

namespace WKHomeWork.Library.Domain.PracownikAggregate.Commands
{
    public class PracownikUpdateHandler : IPracownikUpdateHandler
    {
        private readonly IPracownikRepository _pracownikRepository;

        /// <summary>
        /// Edycja nowego pracownika
        /// </summary>
        /// <param name="pracownikRepository">Repozytorium pracownika</param>
        /// <exception cref="ArgumentNullException">Gdy obiekt 'Repozytorium pracownika' jest puste</exception>
        public PracownikUpdateHandler(IPracownikRepository pracownikRepository)
        {
            _pracownikRepository = pracownikRepository ?? throw new ArgumentNullException("Repozytorium pracownika jest puste");
        }

        /// <summary>
        /// Obsługa komendy
        /// </summary>
        /// <param name="pracownikApi">PracownikUpdate z API</param>
        /// <exception cref="ArgumentNullException">Gdy brak pracownika w repozytorium</exception>
        /// <exception cref="ArgumentNullException">Gdy obiekt PracownikUpdate jest pusty</exception>
        public async Task Handle(PracownikUpdate pracownikApi)
        {
            if (pracownikApi == null) throw new ArgumentNullException("Obiekt PracownikUpdate pusty");
            
            var pracownikFromRepository = await _pracownikRepository.Get(pracownikApi.NumerEwidencyjny) 
                                          ?? throw new ArgumentNullException("Brak pracownika w repozytorium");
            
            pracownikFromRepository.SetNazwisko(new PracownikNazwisko(pracownikApi.Nazwisko));
            pracownikFromRepository.SetPlec(new PracownikPlec(pracownikApi.Plec));
            
            await _pracownikRepository.Update();
        }
    }
    
    public interface IPracownikUpdateHandler : IHandleCommand<PracownikUpdate>
    {
    }
}
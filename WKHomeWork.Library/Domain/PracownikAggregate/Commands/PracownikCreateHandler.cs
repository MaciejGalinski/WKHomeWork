using System;
using System.Threading.Tasks;
using WKHomeWork.Library.Commands;
using WKHomeWork.Library.Domain.PracownikAggregate.Entities;
using WKHomeWork.Library.Domain.PracownikAggregate.Services;
using WKHomeWork.Library.Repository;

namespace WKHomeWork.Library.Domain.PracownikAggregate.Commands
{
    public class PracownikCreateHandler : IPracownikCreateHandler
    {
        private readonly IPracownikRepository _pracownikRepository;
        private readonly IPracownikFactory _pracownikFactory;

        /// <summary>
        /// Tworzenie nowego pracownika
        /// </summary>
        /// <param name="pracownikRepository">Repozytorium pracownika</param>
        /// <param name="pracownikFactory">Pracownik factory</param>
        /// <exception cref="ArgumentNullException">Gdy obiekt Repozytorium pracownika jest puste</exception>
        /// <exception cref="ArgumentNullException">Gdy obiekt Serwis nowego numeru ewidencyjnego jest pusty</exception>
        /// <exception cref="ArgumentNullException">Gdy obiekt 'Fabryka pracownika' jest pusty</exception>
        public PracownikCreateHandler(IPracownikRepository pracownikRepository, IPracownikFactory pracownikFactory)
        {
            _pracownikRepository = pracownikRepository ?? throw new ArgumentNullException("Repozytorium pracownika jest puste");
            _pracownikFactory = pracownikFactory ?? throw new ArgumentNullException("Fabryka pracownika jest pusta");;
        }

        /// <summary>
        ///  Obsługa komendy
        /// </summary>
        /// <param name="pracownikApi">PracownikUpdate z API</param>
        /// <exception cref="ArgumentNullException">Gdy obiekt PracownikAPI jest pusty</exception>
        /// <exception cref="ArgumentNullException">Gdy obiekt Pracownik jest pusty</exception>
        public async Task Handle(PracownikCreate pracownikApi)
        {
            if (pracownikApi == null) throw new ArgumentNullException("Obiekt 'PracownikApi' jest pusty");

            var pracownik = await _pracownikFactory.Get(pracownikApi) 
                            ?? throw new ArgumentNullException("Obiekt 'Pracownik' jest pusty");
           
            await _pracownikRepository.Insert(pracownik);
        }
    }
    
    public interface IPracownikCreateHandler : IHandleCommand<PracownikCreate>
    {
    }
}
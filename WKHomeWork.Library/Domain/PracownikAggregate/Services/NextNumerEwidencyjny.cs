using System;
using System.Threading.Tasks;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;
using WKHomeWork.Library.Repository;

namespace WKHomeWork.Library.Domain.PracownikAggregate.Services
{
    public interface INextNumerEwidencyjnyService
    {
        Task<PracownikNumerEwidencyjny> Get();
    }
    
    public class NextNumerEwidencyjnyService : INextNumerEwidencyjnyService
    {
        private readonly IPracownikRepository _pracownikRepository;

        public NextNumerEwidencyjnyService(IPracownikRepository pracownikRepository)
        {
            _pracownikRepository = pracownikRepository ?? throw new ArgumentNullException("Brak repozytorium pracownika");
        }

        public async Task<PracownikNumerEwidencyjny> Get()
        {
            PracownikNumerEwidencyjny lastNumber = await _pracownikRepository.GetLastNumerEwidencyjny();

            var nextNumerEwidencyjny = lastNumber?.GetNumericValue() + 1 ?? 1;

            return new PracownikNumerEwidencyjny(nextNumerEwidencyjny.ToString());
        }
    }
}
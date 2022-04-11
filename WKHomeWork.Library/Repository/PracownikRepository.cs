using System.Threading.Tasks;
using WKHomeWork.Library.Domain.PracownikAggregate;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;

namespace WKHomeWork.Library.Repository
{
    public interface IPracownikRepository
    {
        Task Insert(Pracownik pracownik);
        
        Task<Pracownik> Get(string numerEwidencyjny);

        Task Update();

        Task<PracownikNumerEwidencyjny> GetLastNumerEwidencyjny();
    }
}
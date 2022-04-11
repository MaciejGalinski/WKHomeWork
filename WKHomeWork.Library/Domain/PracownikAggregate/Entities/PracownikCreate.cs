using WKHomeWork.Library.Commands;

namespace WKHomeWork.Library.Domain.PracownikAggregate.Entities
{
    public class PracownikCreate : PracownikFromApi, ICommand
    {
        public PracownikCreate(string nazwisko, string plec) : base(nazwisko, plec)
        {
            
        }
    }
}
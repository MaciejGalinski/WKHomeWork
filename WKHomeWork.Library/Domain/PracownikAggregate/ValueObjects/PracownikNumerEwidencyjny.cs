using System;
using WKHomeWork.Library.Domain.Helpers;

namespace WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects
{
    public class PracownikNumerEwidencyjny : ValueNumerEwidencyjnyObject
    {
        /// <summary>
        /// Numer ewidencyjny pracownika w formacie string z wiodącymi zerami (w sumie 8 znaków)
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException">Gdy wartość obiektu pusta.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Gdy wartość obiektu jest niepoprawna (8 cyft)</exception>
        public PracownikNumerEwidencyjny(string id) : base(id)
        {
            
        }
    }
}
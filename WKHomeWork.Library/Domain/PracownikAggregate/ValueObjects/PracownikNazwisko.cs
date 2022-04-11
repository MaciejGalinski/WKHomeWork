using System;
using System.Collections.Generic;
using WKHomeWork.Library.Domain.Helpers;

namespace WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects
{
    public class PracownikNazwisko : ValueStringObject
    {
        /// <summary>
        /// Nazwisko pracownika z maksymalną wartością 50 znakow
        /// </summary>
        /// <param name="nazwisko">Nazwisko pracownika</param>
        /// <exception cref="ArgumentNullException">Gdy wartość obiektu pusta.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Gdy przekroczono ilość znaków</exception>
        public PracownikNazwisko(string nazwisko) : base(nazwisko, 50, "nazwisko pracownika")
        {
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
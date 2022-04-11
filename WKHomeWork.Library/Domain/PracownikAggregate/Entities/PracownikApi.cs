using System;

namespace WKHomeWork.Library.Domain.PracownikAggregate.Entities
{
    public abstract class PracownikFromApi
    {
        public string Nazwisko { get; set; }
        public string Plec { get; set; }

        /// <summary>
        /// Pracownik z Api
        /// </summary>
        /// <param name="nazwisko"></param>
        /// <param name="plec"></param>
        /// <exception cref="ArgumentNullException">Brak nazwiska</exception>
        /// <exception cref="ArgumentNullException">Brak płci</exception>
        protected PracownikFromApi(string nazwisko, string plec)
        {
            if (string.IsNullOrWhiteSpace(nazwisko)) throw new ArgumentNullException("Brak nazwiska");
            if (string.IsNullOrWhiteSpace(plec)) throw new ArgumentNullException("Brak płci");
            
            Nazwisko = nazwisko;
            Plec = plec;
        }
    }
}
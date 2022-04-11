using System;
using System.Collections.Generic;
using WKHomeWork.Library.Domain.Helpers;
using WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects;

namespace WKHomeWork.Library.Domain.PracownikAggregate
{
    public class Pracownik : ValueObject
    {
        public PracownikNumerEwidencyjny NumerEwidencyjny { get; private set; }
        public PracownikNazwisko Nazwisko { get; private set; }
        public PracownikPlec Plec { get; private set; }

        /// <summary>
        /// Pracownik
        /// </summary>
        /// <param name="numerEwidencyjny">Obiekt Numer Ewidencyjny</param>
        /// <param name="nazwisko">Obiekt Nazwisko</param>
        /// <param name="plec">Obiekt Płeć</param>
        /// <exception cref="ArgumentNullException">Wyjątek przy pustych obiektach</exception>
        public Pracownik(PracownikNumerEwidencyjny numerEwidencyjny, PracownikNazwisko nazwisko, PracownikPlec plec)
        {
            NumerEwidencyjny = numerEwidencyjny ?? throw new ArgumentNullException("Brak obiektu 'numer ewidencyjny'");
            Nazwisko = nazwisko ?? throw new ArgumentNullException("Brak obiektu 'nazwisko'");
            Plec = plec ?? throw new ArgumentNullException("Brak obiektu 'płeć'");
        }

        public void SetNazwisko(PracownikNazwisko nazwisko)
        {
            Nazwisko = nazwisko ?? throw new NullReferenceException("Brak obiektu 'nazwisko'");
        }
        
        public void SetNumerEwidencyjny(PracownikNumerEwidencyjny numerEwidencyjny)
        {
            NumerEwidencyjny = numerEwidencyjny ?? throw new NullReferenceException("Brak obiektu 'numer ewidencyjny'");
        }
        public void SetPlec(PracownikPlec plec)
        {
            Plec = plec;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nazwisko;
            yield return Plec;
            yield return NumerEwidencyjny;
        }
    }
}
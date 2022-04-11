using System;
using WKHomeWork.Library.Commands;

namespace WKHomeWork.Library.Domain.PracownikAggregate.Entities
{
    public class PracownikUpdate : PracownikFromApi, ICommand
    {
        public string NumerEwidencyjny { get; set; }

        /// <summary>
        /// Pracownik Update z Api
        /// </summary>
        /// <param name="nazwisko"></param>
        /// <param name="plec"></param>
        /// <param name="numerEwidencyjny"></param>
        public PracownikUpdate(string nazwisko, string plec, string numerEwidencyjny) : base(nazwisko, plec)
        {
            if (string.IsNullOrWhiteSpace(numerEwidencyjny)) throw new ArgumentNullException("Brak numeru ewidencyjnego");

            NumerEwidencyjny = numerEwidencyjny;
        }
    }
}
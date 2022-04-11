using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WKHomeWork.Library.Domain.Helpers
{
    public abstract class ValueNumerEwidencyjnyObject : ValueObject
    {
        public string Value { get; }
        
        /// <summary>
        /// Wartość numer ewidencyjny
        /// </summary>
        /// <param name="value">Wartość obiektu</param>
        /// <exception cref="ArgumentNullException">Gry wartość obiektu pusta.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Gry wartość obiektu jest niepoprawna (8 cyft)</exception>
        protected ValueNumerEwidencyjnyObject(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentNullException($"Pusta wartość obiektu Id");

            Value = GenerateId(value);
        }

        private string GenerateId(string value)
        {
            if (!Regex.IsMatch(value, @"^\d{1,8}$"))
                throw new ArgumentOutOfRangeException($"Niepoprawna wartość obiektu Id");

            int valueInNumber = int.Parse(value);

            return valueInNumber.ToString("00000000");
        }

        public int GetNumericValue()
        {
            return int.Parse(Value);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
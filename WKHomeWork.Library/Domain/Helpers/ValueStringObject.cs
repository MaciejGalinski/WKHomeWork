using System;
using System.Collections.Generic;

namespace WKHomeWork.Library.Domain.Helpers
{
    public abstract class ValueStringObject : ValueObject
    {
        public string Value { get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Wartość obiektu</param>
        /// <param name="maxLength">Maksymalna długość wartości.</param>
        /// <param name="valueName">Nazwa obiektu</param>
        /// <exception cref="ArgumentNullException">Gry wartość obiektu pusta.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Gry przekroczono ilość znaków</exception>
        protected ValueStringObject(string value, int maxLength = 0, string valueName = "")
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentNullException($"Pusta wartość obiektu {valueName}");
            
            value = value.Trim();
            
            if (value.Length > maxLength) 
                throw new ArgumentOutOfRangeException($"Przekroczono ilość znaków {maxLength} obiektu {valueName}");

            Value = value;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
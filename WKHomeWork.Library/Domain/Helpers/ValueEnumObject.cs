using System;
using System.Collections.Generic;

namespace WKHomeWork.Library.Domain.Helpers
{
    public abstract class ValueEnumObject : ValueObject
    {
        public Enum Value { get; }
        
        /// <summary>
        /// Obiekt ValueEnumObject
        /// </summary>
        /// <param name="value">Wartość enum</param>
        protected ValueEnumObject(Enum value)
        {
            Value = value;
        }

        /// <summary>
        /// Obiekt ValueEnumObject
        /// </summary>
        /// <param name="value">wartość string</param>
        /// <param name="enumType"></param>
        /// <exception cref="ArgumentException"></exception>
        protected ValueEnumObject(string value, Type enumType)
        {
            if (!Enum.TryParse(enumType, value, true, out var enumFromParse))
                throw new ArgumentException("Błędny argument płci");

            Value = (Enum) enumFromParse;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
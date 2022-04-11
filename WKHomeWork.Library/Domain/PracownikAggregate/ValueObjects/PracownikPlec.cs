using System.Collections.Generic;
using WKHomeWork.Library.Domain.Helpers;
using WKHomeWork.Library.Domain.PracownikAggregate.Enums;

namespace WKHomeWork.Library.Domain.PracownikAggregate.ValueObjects
{
    public class PracownikPlec : ValueEnumObject
    {
        /// <summary>
        /// Płeć pracowika
        /// </summary>
        /// <param name="plec"></param>
        public PracownikPlec(PracownikPlecEnum plec) : base(plec)
        {
        }

        /// <summary>
        /// Płeć pracowika
        /// </summary>
        /// <param name="plec"></param>
        public PracownikPlec(string plec) : base(plec, typeof(PracownikPlecEnum))
        {
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
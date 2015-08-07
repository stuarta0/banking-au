using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Converters
{
    /// <summary>
    /// Provides conversion to a padding string with a right-justified decimal represented as cents with remaining space filled with zeros.
    /// </summary>
    public class CurrencyConverter : ConverterBase
    {
        private string _format;

        /// <summary>
        /// Default implementation uses 10 characters.
        /// </summary>
        public CurrencyConverter()
            : this(10)
        { }
        public CurrencyConverter(int fieldLength)
        {
            _format = String.Concat("D", fieldLength);
        }

        public override string FieldToString(object from)
        {
            if (from is decimal)
                return ((int)(((decimal)from) * 100)).ToString(_format);
            return 0.ToString(_format);
        }

        public override object StringToField(string from)
        {
            decimal result;
            if (Decimal.TryParse(from, out result))
                return result / 100;
            return 0;
        }
    }
}

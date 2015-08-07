using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Converters
{
    /// <summary>
    /// Provides conversion from dollars to cents.
    /// </summary>
    public class CurrencyConverter : ConverterBase
    {
        public CurrencyConverter()
        { }

        public override string FieldToString(object from)
        {
            if (from is decimal)
                return ((int)(((decimal)from) * 100)).ToString();
            return string.Empty;
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

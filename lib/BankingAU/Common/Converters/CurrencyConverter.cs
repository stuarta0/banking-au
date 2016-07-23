using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Common.Converters
{
    /// <summary>
    /// Provides conversion from dollars to cents.
    /// </summary>
    public class CurrencyConverter : ConverterBase
    {
        private bool _enforceUnsigned;

        public CurrencyConverter(bool enforceUnsigned = false)
        {
            _enforceUnsigned = enforceUnsigned;
        }

        public override string FieldToString(object from)
        {
            if (from is decimal)
            {
                var value = ((int)(((decimal)from) * 100));
                return (_enforceUnsigned ? Math.Abs(value) : value).ToString();
            };
            return string.Empty;
        }

        public override object StringToField(string from)
        {
            decimal result;
            if (Decimal.TryParse(from, out result))
                return (_enforceUnsigned ? Math.Abs(result) : result) / 100;
            return 0;
        }
    }

    /// <summary>
    /// Convenience class to improve readability.
    /// </summary>
    public class UnsignedCurrencyConverter : CurrencyConverter
    {
        public UnsignedCurrencyConverter()
            : base(true)
        { }
    }
}

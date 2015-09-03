using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Common.Converters
{
    /// <summary>
    /// Provides string formatting when converting FieldToString, and uses Convert.ChangeType when converting back.
    /// </summary>
    public class StringFormatConverter : ConverterBase
    {
        private Type _type;
        private string _format;
        public StringFormatConverter(Type fieldType, string format)
        {
            _type = fieldType;
            _format = String.Concat("{0:", format, "}");
        }

        public override string FieldToString(object from)
        {
            return String.Format(_format, from);
        }

        public override object StringToField(string from)
        {
            try { return Convert.ChangeType(from, _type); }
            catch { return null; }
        }
    }
}

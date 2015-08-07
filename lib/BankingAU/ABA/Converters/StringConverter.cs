using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Converters
{
    public class StringConverter : ConverterBase
    {
        private int _length;
        public StringConverter(int fieldLength)
        {
            _length = fieldLength;
        }

        public override string FieldToString(object from)
        {
            // assumes length of from < _length
            if (from is string)
                return ((string)from).PadLeft(_length);
            return string.Empty.PadLeft(_length);
        }

        public override object StringToField(string from)
        {
            return (from ?? string.Empty).TrimStart();
        }
    }
}

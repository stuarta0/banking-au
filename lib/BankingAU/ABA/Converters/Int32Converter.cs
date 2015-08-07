using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Converters
{
    public class Int32Converter : ConverterBase
    {
        private string _format;
        public Int32Converter()
            : this(10)
        { }
        public Int32Converter(int fieldLength)
        {
            _format = String.Concat("D", fieldLength);
        }

        public override string FieldToString(object from)
        {
            int x = 0;
            if (from is Int32)
                x = (Int32)from;
            else
            {
                try { x = Convert.ToInt32(from); }
                catch { return 0.ToString(_format); }
            }

            return x.ToString(_format);
        }

        public override object StringToField(string from)
        {
            try { return Int32.Parse(from); }
            catch { return 0; }
        }
    }
}

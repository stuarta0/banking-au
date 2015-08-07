using Banking.AU.Common.Attributes;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Converters
{
    public class EnumConverter : ConverterBase
    {
        private Dictionary<object, string> _lookup;
        public EnumConverter(Type enumType)
        {
            _lookup = new Dictionary<object,string>();
            foreach (var e in Enum.GetValues(enumType))
            {
                _lookup.Add(e, e.ToString());
                var attrs = enumType.GetField(e.ToString()).GetCustomAttributes(typeof(FileRepresentationAttribute), false);
                if (attrs.Length == 1)
                    _lookup[e] = ((FileRepresentationAttribute)attrs[0]).Representation;
            }
        }

        public override string FieldToString(object from)
        {
            if (_lookup.ContainsKey(from))
                return _lookup[from];
            return base.FieldToString(from);
        }

        public override object StringToField(string from)
        {
            foreach (var pair in _lookup)
                if (pair.Value == from)
                    return pair.Key;
            return 0;
        }
    }
}

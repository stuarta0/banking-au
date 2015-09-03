using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Common.Converters
{
    [Flags]
    public enum ReplaceType
    {
        Comma = 1,
        DoubleQuote = 2,
        Newline = 4
    }

    /// <summary>
    /// Provides string replace bidirectionally.
    /// </summary>
    public class StringReplaceConverter : ConverterBase
    {
        private List<KeyValuePair<string, string>> _replaces;
        public StringReplaceConverter(ReplaceType kind)
        {
            if ((kind & ReplaceType.Comma) == ReplaceType.Comma)
                init(",", "");
            if ((kind & ReplaceType.DoubleQuote) == ReplaceType.DoubleQuote)
                init("\"", "");
            if ((kind & ReplaceType.Newline) == ReplaceType.Newline)
            {
                init("\n", "");
                init(Environment.NewLine, "");
                init("\r", "");
            }
        }
        public StringReplaceConverter(string oldValue, string newValue)
        {
            init(oldValue, newValue);
        }
        private void init(string oldValue, string newValue)
        {
            if (_replaces == null)
                _replaces = new List<KeyValuePair<string, string>>();
            _replaces.Add(new KeyValuePair<string, string>(oldValue, newValue));
        }

        public override string FieldToString(object from)
        {
            if (from != null)
            {
                var sb = new StringBuilder(from.ToString());
                foreach (var r in _replaces)
                    sb.Replace(r.Key, r.Value);
                return sb.ToString();
            }
            return string.Empty;
        }

        public override object StringToField(string from)
        {
            if (from != null)
            {
                var sb = new StringBuilder(from);
                foreach (var r in _replaces)
                    sb.Replace(r.Key, r.Value);
                return sb.ToString();
            }
            return from;
        }
    }
}

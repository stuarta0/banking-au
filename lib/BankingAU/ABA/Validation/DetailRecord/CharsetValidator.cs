using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA.Validation.DetailRecord
{
    /// <summary>
    /// Ensures a string field matches the limited charset for ABA files.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CharsetValidator<T> : StringFieldValidator<T>
    {
        private const string PATTERN = @"\s\.\<\>\(\)\+\$\*\{\}\-\?\\/,;:!@#$%&'\x22=~`|_a-zA-Z0-9";
        private static Regex Charset = new Regex(String.Concat("^[", PATTERN, "]+$"));
        private static Regex Replacement = new Regex(String.Concat("[^", PATTERN, "]"));

        public CharsetValidator(int maxLength, GetValue<T, string> get)
            : base(maxLength, Charset, get)
        { }
        public CharsetValidator(int maxLength, GetValue<T, string> get, SetValue<T, string> set)
            : base(maxLength, Charset, Replacement, get, set)
        { }
    }
}

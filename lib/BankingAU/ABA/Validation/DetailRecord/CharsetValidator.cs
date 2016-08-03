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
        private static Regex Charset = new Regex(@"^[\s\.\<\>\(\)\+\$\*\{\}\-\?\\/,;:!@#$%&'\x22=~`|_a-zA-Z0-9]+$");
        private static Regex Replacement = new Regex(@"[^\s\.\<\>\(\)\+\$\*\{\}\-\?\\/,;:!@#$%&'\x22=~`|_a-zA-Z0-9]");

        public CharsetValidator(int maxLength, GetValue<T, string> get)
            : base(maxLength, Charset, get)
        { }
        public CharsetValidator(int maxLength, GetValue<T, string> get, SetValue<T, string> set)
            : base(maxLength, Charset, Replacement, get, set)
        { }
    }
}

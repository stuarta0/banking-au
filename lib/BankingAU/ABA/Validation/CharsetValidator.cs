using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA.Validation
{
    public class CharsetValidator<T> : StringFieldValidator<T>
    {
        private static Regex charset = new Regex(@"^[\s\.\<\>\(\)\+\$\*\{\}\-\?\\/,;:!@#$%&'\x22=~`|_a-zA-Z0-9]+$");
        public CharsetValidator(int maxLength, GetValue<T, string> get)
            : base(maxLength, charset, get)
        { }
        public CharsetValidator(int maxLength, GetValue<T, string> get, SetValue<T, string> set)
            : base(maxLength, charset, get, set)
        { }
    }
}

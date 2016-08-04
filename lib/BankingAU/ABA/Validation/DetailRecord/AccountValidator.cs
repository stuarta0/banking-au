using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA.Validation.DetailRecord
{
    /// <summary>
    /// Ensures a string field matches the limited character set for account numbers for ABA files.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AccountValidator<T> : StringFieldValidator<T>
    {
        private const string PATTERN = @"0-9a-zA-Z\-\s";
        private static Regex Charset     = new Regex(String.Concat("^[", PATTERN, "]+$"));
        private static Regex Replacement = new Regex(String.Concat("[^", PATTERN, "]"));

        public AccountValidator(int maxLength, GetValue<T, string> get)
            : base(maxLength, Charset, get)
        { }
        public AccountValidator(int maxLength, GetValue<T, string> get, SetValue<T, string> set)
            : base(maxLength, Charset, Replacement, get, set)
        { }
    }
}

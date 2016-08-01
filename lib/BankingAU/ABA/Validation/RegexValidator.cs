using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA.Validation
{
    /// <summary>
    /// Checks values against a Regex criteria.  If cleaning, provide a replacement Regex that contains values to be replaced.
    /// </summary>
    /// <example>
    /// var v = new RegexValidator("^[0-9]{4}$", "[^0-9]", ...);
    /// v.Validate("1234");    // no errors
    /// v.Validate("1234abc"); // errors
    /// v.Clean("1234abc");    // "1234"
    /// v.Clean("abcd");       // ""; exception, cleaned string does not match requirement
    /// </example>
    public class RegexValidator<T> : IValidator<T>
    {
        private Regex _charset, _replacement;
        private GetValue<T, string> _get;
        private SetValue<T, string> _set;
        public RegexValidator(Regex charset, GetValue<T, string> get)
        {
            _charset = charset;
            _get = get;
        }
        public RegexValidator(Regex charset, Regex replacement, GetValue<T, string> get, SetValue<T, string> set)
            : this(charset, get)
        {
            _replacement = replacement;
            _set = set;
        }

        private IEnumerable<IError> Validate(string value)
        {
            if (value == null)
                yield return new Error("Value cannot be null");
            else if (!_charset.IsMatch(value))
                yield return new Error(String.Format("Value '{0}' does not match pattern: {1}", value, _charset.ToString()));
        }

        public void Clean(T item)
        {
            if (_set == null || _replacement == null)
                throw new MissingMethodException("Cleaning string requires a set method and replacement regex.");
            var value = _get(item);
            if (value == null)
                throw new ArgumentNullException("Value cannot be null");
            value = _replacement.Replace(value, "");
            foreach (var e in Validate(value))
                throw new FormatException(e.Message);
            _set(item, value);    
        }

        public IEnumerable<IError> Validate(T item)
        {
            return Validate(_get(item));
        }
    }
}

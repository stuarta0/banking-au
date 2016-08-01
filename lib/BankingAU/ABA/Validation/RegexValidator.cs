using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA.Validation
{
    class RegexValidator<T> : IValidator<T>
    {
        private Regex _charset;
        private GetValue<T, string> _get;
        private SetValue<T, string> _set;
        public RegexValidator(Regex charset, GetValue<T, string> get)
        {
            _charset = charset;
            _get = get;
        }
        public RegexValidator(Regex charset, GetValue<T, string> get, SetValue<T, string> set)
            : this(charset, get)
        {
            _set = set;
        }

        public void Clean(T item)
        {
            // TODO: replace inverse _charset regex with empty string
            throw new NotImplementedException();
        }

        public IEnumerable<IError> Validate(T item)
        {
            var value = _get(item);
            if (!_charset.IsMatch(value))
                yield return new Error(String.Format("Value '{0}' does not match pattern: {1}", value, _charset.ToString()));
        }
    }
}

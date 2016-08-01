using System;
using System.Collections.Generic;
using System.Text;
using Banking.AU.ABA.Records;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA.Validation
{
    public class BsbValidator<T> : IValidator<T>
    {
        private static Regex rvalid = new Regex(@"^\d{3}\-\d{3}$");
        private static Regex rclean = new Regex(@"^[\s_\-\.]*(?:(\d)[\s_\-\.]*){6}$");

        private GetValue<T, string> _get;
        private SetValue<T, string> _set;
        public bool AllowNull { get; set; }
        public BsbValidator(GetValue<T, string> get)
        {
            AllowNull = false;
            _get = get;
        }
        public BsbValidator(GetValue<T, string> get, SetValue<T, string> set)
            : this(get)
        {
            _set = set;
        }
        
        public void Clean(T item)
        {
            if (_set == null)
                throw new MissingMethodException("Cleaning BSB requires a set method.");
            var bsb = _get(item);
            if (String.IsNullOrEmpty(bsb))
            {
                if (!AllowNull)
                    throw new ArgumentNullException("BSB cannot be empty");
            }
            var match = rclean.Match(bsb);
            if (!match.Success)
                throw new FormatException("BSB must be in the format \"000-000\"");

            var sb = new StringBuilder();
            for (int i = 0; i < match.Groups[1].Captures.Count; i++)
            {
                if (i == 3) sb.Append("-");
                sb.Append(match.Groups[1].Captures[i].Value);
            }
            _set(item, sb.ToString());
        }

        public IEnumerable<IError> Validate(T item)
        {
            var bsb = _get(item);
            if (String.IsNullOrEmpty(bsb))
            {
                if (!AllowNull)
                    yield return new Error("BSB cannot be empty");
            }
            else if (!rvalid.IsMatch(bsb))
                yield return new Error("BSB must be in the format \"000-000\"");
        }
    }
}

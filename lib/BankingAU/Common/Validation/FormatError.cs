using System;
using System.Text.RegularExpressions;

namespace Banking.AU.Common.Validation
{
    public class FormatError<T> : ValidationError<T>
        where T : class
    {
        public FormatError(T item, string member)
            : base(item, member, string.Empty)
        {
            Message = String.Concat(member, " does not meet the format criteria.");
        }

        public FormatError(T item, string member, string format)
            : base(item, member, string.Empty)
        {
            Message = String.Concat(member, " must be in the format ", format, ".");
        }

        public FormatError(T item, string member, Regex format)
            : this(item, member, format.ToString()) { }
    }
}

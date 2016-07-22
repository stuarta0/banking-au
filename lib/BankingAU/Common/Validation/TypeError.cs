using System;

namespace Banking.AU.Common.Validation
{
    public class TypeError<T> : ValidationError<T>
        where T : class
    {
        public TypeError(T item, string member)
            : base(item, member, string.Empty)
        {
            Message = String.Concat(member, " is the incorrect type.");
        }

        public TypeError(T item, string member, Type target)
            : base(item, member, string.Empty)
        {
            Message = String.Concat(member, " must be of type ", target.FullName, ".");
        }
    }
}

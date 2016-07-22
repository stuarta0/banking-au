using System;

namespace Banking.AU.Common.Validation
{
    public class TruncationError<T> : ValidationError<T>
        where T : class
    {
        public TruncationError(T item, string member)
            : base(item, member)
        {
            Message = String.Concat(member, " will be truncated.");
        }

        public TruncationError(T item, string member, int max)
            : base(item, member)
        {
            Message = String.Concat(member, " must be less than ", max, " or it will be truncated.");
        }
    }
}

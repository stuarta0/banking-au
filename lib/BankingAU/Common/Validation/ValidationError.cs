using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Common.Validation
{
    public class ValidationError<T> : IValidationError<T>
        where T : class
    {
        public T Item { get; set; }
        public string Member { get; set; }
        public string Message { get; set; }

        public ValidationError(string message)
            :this(null, message)
        {

        }
        public ValidationError(T item, string message)
            :this(item, null, message)
        {

        }
        public ValidationError(T item, string member, string message)
        {
            Item = item;
            Member = member;
            Message = message;
        }
    }
}

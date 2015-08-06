using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Common.Validation
{
    public interface IValidationError<T>
    {
        T Item { get; set; }
        string Member { get; set; }
        string Message { get; set; }
    }
}

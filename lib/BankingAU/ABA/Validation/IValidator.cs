using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation
{
    public interface IValidator<T>
    {
        IEnumerable<Exception> Validate(T item);
        void Clean(T item);
    }
}

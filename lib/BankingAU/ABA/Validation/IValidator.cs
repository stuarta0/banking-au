using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation
{
    public interface IValidator<T>
    {
        IEnumerable<IError> Validate(T item);
        void Clean(T item);
    }
}

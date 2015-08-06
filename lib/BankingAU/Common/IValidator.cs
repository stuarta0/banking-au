using Banking.AU.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Common
{
    public interface IValidator<T>
    {
        IList<IValidationError<T>> Validate(T item);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation
{
    public delegate U GetValue<T, U>(T item);
    public delegate void SetValue<T, U>(T item, U value);
}

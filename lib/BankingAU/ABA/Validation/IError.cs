using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation
{
    public interface IError
    {
        string Message { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation
{
    public class Error : IError
    {
        public string Message
        {
            get; private set;
        }

        public Error(string message)
        {
            Message = message;
        }
    }
}

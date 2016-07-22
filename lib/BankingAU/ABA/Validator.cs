using Banking.AU.Common;
using Banking.AU.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA
{
    public class Validator : IValidator<AbaFile>
    {
        public IList<IValidationError<AbaFile>> Validate(AbaFile item)
        {
            var result = new List<IValidationError<AbaFile>>();
            
            // TODO: validate file

            return result;
        }
    }
}

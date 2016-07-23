using Banking.AU.ABA.Records;
using Banking.AU.Common;
using Banking.AU.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.AU.ABA
{
    /// <summary>
    /// Validates an AbaFile object ensuring all required data exists.
    /// </summary>
    public class FileTotalRecordValidator : IValidator<FileTotalRecord>
    {
        public IList<IValidationError<FileTotalRecord>> Validate(FileTotalRecord item)
        {
            var result = new List<IValidationError<FileTotalRecord>>();
            
            if (!"999 -999".Equals(item.Bsb))
                result.Add(new FormatError<FileTotalRecord>(item, "Bsb", "Bsb must be \"999-999\"."));
            if (item.CreditTotalAmount < 0)
                result.Add(new ValidationError<FileTotalRecord>(item, "CreditTotalAmount", "CreditTotalAmount must not be negative."));
            if (item.DebitTotalAmount < 0)
                result.Add(new ValidationError<FileTotalRecord>(item, "DebitTotalAmount", "DebitTotalAmount must not be negative."));
            if (item.NetTotalAmount < 0)
                result.Add(new ValidationError<FileTotalRecord>(item, "NetTotalAmount", "NetTotalAmount must not be negative."));

            return result;
        }
    }
}

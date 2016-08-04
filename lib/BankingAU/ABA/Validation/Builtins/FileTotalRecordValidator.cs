using R = Banking.AU.ABA.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.Builtins
{
    /// <summary>
    /// Validates an individual FileTotalRecord object.
    /// Note: only checks against currency bounds.  Use <see cref="Banking.AU.ABA.Validation.AbaFile.FileTotalValidator"/> to also validate correct totals.
    /// </summary>
    public class FileTotalRecordValidator : CompositeValidator<R.FileTotalRecord>
    {
        public FileTotalRecordValidator()
        {
            _validators = new List<IValidator<R.FileTotalRecord>>()
            {
                new BsbValidator<R.FileTotalRecord>(r => r.Bsb, (r,v) => { }),
                new CurrencyValidator<R.FileTotalRecord>(10, r => r.CreditTotalAmount, (r,v) => r.CreditTotalAmount = v),
                new CurrencyValidator<R.FileTotalRecord>(10, r => r.DebitTotalAmount, (r,v) => r.DebitTotalAmount = v),
                new CurrencyValidator<R.FileTotalRecord>(10, r => r.NetTotalAmount, (r,v) => r.NetTotalAmount = v)
            };
        }
    }
}

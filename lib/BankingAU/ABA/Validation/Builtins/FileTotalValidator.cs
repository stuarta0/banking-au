using R = Banking.AU.ABA.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.Builtins
{
    public class FileTotalValidator : CompositeValidator<R.FileTotalRecord>
    {
        public FileTotalValidator()
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

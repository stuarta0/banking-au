using System.Collections.Generic;
using R = Banking.AU.ABA.Records;

namespace Banking.AU.ABA.Validation.Builtins
{
    public class DetailRecordValidator : CompositeValidator<R.DetailRecord>
    {
        public DetailRecordValidator()
        {
            _validators = new List<IValidator<R.DetailRecord>>()
            {
                new BsbValidator<R.DetailRecord>(r => r.Bsb, (r,v) => r.Bsb = v),
                new CurrencyValidator<R.DetailRecord>(10, r => r.Amount, (r,v) => r.Amount = v),
                new CurrencyValidator<R.DetailRecord>(8, r => r.WithholdingTaxAmount),
                new BsbValidator<R.DetailRecord>(r => r.TraceRecordBsb, (r,v) => r.TraceRecordBsb = v) { AllowNull = true }
            };
        }
    }
}

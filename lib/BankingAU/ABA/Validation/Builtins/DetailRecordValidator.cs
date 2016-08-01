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
                // TODO: account number
                new CurrencyValidator<R.DetailRecord>(10, r => r.Amount, (r,v) => r.Amount = v),
                new CharsetValidator<R.DetailRecord>(32, r => r.TargetAccountTitle, (r,v) => r.TargetAccountTitle = v),
                new CharsetValidator<R.DetailRecord>(18, r => r.LodgementReference, (r,v) => r.LodgementReference = v),
                new BsbValidator<R.DetailRecord>(r => r.TraceRecordBsb, (r,v) => r.TraceRecordBsb = v) { AllowNull = true },
                // TODO: trace record account number
                new CharsetValidator<R.DetailRecord>(16, r => r.RemitterName, (r,v) => r.RemitterName = v),
                new CurrencyValidator<R.DetailRecord>(8, r => r.WithholdingTaxAmount)
            };
        }
    }
}

using Banking.AU.ABA.Validation.DetailRecord;
using System.Collections.Generic;
using R = Banking.AU.ABA.Records;

namespace Banking.AU.ABA.Validation.Builtins
{
    /// <summary>
    /// Validates an individual DetailRecord object.
    /// </summary>
    public class DetailRecordValidator : CompositeValidator<R.DetailRecord>
    {
        public DetailRecordValidator()
        {
            _validators = new List<IValidator<R.DetailRecord>>()
            {
                new BsbValidator<R.DetailRecord>(r => r.Bsb, (r,v) => r.Bsb = v),
                new AccountValidator<R.DetailRecord>(9, r => r.AccountNumber, (r,v) => r.AccountNumber = v),
                new CurrencyValidator<R.DetailRecord>(10, r => r.Amount, (r,v) => r.Amount = v),
                new CharsetValidator<R.DetailRecord>(32, r => r.TargetAccountTitle, (r,v) => r.TargetAccountTitle = v),
                new CharsetValidator<R.DetailRecord>(18, r => r.LodgementReference, (r,v) => r.LodgementReference = v),
                new BsbValidator<R.DetailRecord>(r => r.TraceRecordBsb, (r,v) => r.TraceRecordBsb = v) { AllowNull = true },
                new AccountValidator<R.DetailRecord>(9, r => r.TraceRecordAccountNumber, (r,v) => r.TraceRecordAccountNumber = v) { AllowNull = true },
                new CharsetValidator<R.DetailRecord>(16, r => r.RemitterName, (r,v) => r.RemitterName = v),
                new CurrencyValidator<R.DetailRecord>(8, r => r.WithholdingTaxAmount)
            };
        }
    }
}

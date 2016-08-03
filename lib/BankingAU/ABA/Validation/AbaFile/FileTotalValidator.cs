using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    /// <summary>
    /// Generates or updates a FileTotalRecord in an AbaFile object with correct values.
    /// </summary>
    public class FileTotalValidator : CompositeValidator<R.AbaFile>
    {
        public FileTotalValidator()
            : base()
        {
            _validators = new List<IValidator<R.AbaFile>>()
            {
                new DebitTotalAmountValidator(),
                new CreditTotalAmountValidator(),
                new NetTotalAmountValidator(),
                new CountOfType1Validator()
            };
        }

        public override void Clean(R.AbaFile item)
        {
            if (item.DetailRecords == null)
                return;
            if (item.FileTotalRecord == null)
                item.FileTotalRecord = new Records.FileTotalRecord();
            base.Clean(item);
        }

        public override IEnumerable<Exception> Validate(R.AbaFile item)
        {
            if (item.FileTotalRecord == null)
                yield return new ArgumentNullException("FileTotalRecord must be provided");
            foreach (var e in base.Validate(item)) yield return e;
        }
    }
}

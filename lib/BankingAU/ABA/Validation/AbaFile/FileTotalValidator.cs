using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    /// <summary>
    /// Generates or updates a FileTotalRecord in an AbaFile object with correct values.
    /// </summary>
    public class FileTotalValidator : CompositeValidator<R.AbaFile>, ICanAdd
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
                yield return new ArgumentNullException("FileTotalRecord must be provided", (Exception)null);
            else
                foreach (var e in base.Validate(item)) yield return e;
        }

        /// <summary>
        /// A helper function to check whether one or more DetailRecords can be added to an ABA file while maintaining aggregation validity (counts and totals).
        /// </summary>
        public virtual bool CanAdd(R.AbaFile file, params R.Records.DetailRecord[] records)
        {
            bool canAdd = true;
            foreach (var v in _validators)
            {
                if (v is ICanAdd)
                    canAdd &= ((ICanAdd)v).CanAdd(file, records);
            }
            return canAdd;
        }

    }
}

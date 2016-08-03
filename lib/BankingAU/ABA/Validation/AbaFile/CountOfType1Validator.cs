using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    public class CountOfType1Validator : IValidator<R.AbaFile>
    {
        protected virtual IEnumerable<Exception> InternalValidate(R.AbaFile item)
        {
            if (item.DetailRecords.Count == 0)
                yield return new ArgumentOutOfRangeException("Must have at least one detail record");
            if (item.DetailRecords.Count >= 1000000)
                yield return new ArgumentOutOfRangeException("Count of detail records cannot exceed 1,000,000");
        }

        public void Clean(R.AbaFile item)
        {
            foreach (var e in InternalValidate(item)) throw e;
            item.FileTotalRecord.CountOfType1 = item.DetailRecords.Count;
        }

        public IEnumerable<Exception> Validate(R.AbaFile item)
        {
            foreach (var e in InternalValidate(item)) yield return e;
            if (item.FileTotalRecord.CountOfType1 != item.DetailRecords.Count)
                yield return new Exception("CountOfType1 is does not match count of detail records");
        }
    }
}

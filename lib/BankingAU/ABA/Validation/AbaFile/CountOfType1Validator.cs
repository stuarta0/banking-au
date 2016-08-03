using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;
using Banking.AU.ABA.Records;

namespace Banking.AU.ABA.Validation.AbaFile
{
    /// <summary>
    /// Validator for calculating FileTotalRecord CountOfType1 from DetailRecords.
    /// </summary>
    public class CountOfType1Validator : IValidator<R.AbaFile>, ICanAdd
    {
        protected virtual IEnumerable<Exception> InternalValidate(ICollection<R.Records.DetailRecord> items)
        {
            if (items.Count == 0)
                yield return new ArgumentOutOfRangeException("Must have at least one detail record", (Exception)null);
            if (items.Count >= 1000000)
                yield return new ArgumentOutOfRangeException("Count of detail records cannot exceed 1,000,000", (Exception)null);
        }

        public void Clean(R.AbaFile item)
        {
            foreach (var e in InternalValidate(item.DetailRecords)) throw e;
            item.FileTotalRecord.CountOfType1 = item.DetailRecords.Count;
        }

        public IEnumerable<Exception> Validate(R.AbaFile item)
        {
            foreach (var e in InternalValidate(item.DetailRecords)) yield return e;
            if (item.FileTotalRecord.CountOfType1 != item.DetailRecords.Count)
                yield return new Exception("CountOfType1 is does not match count of detail records");
        }

        /// <summary>
        /// A helper function to check whether one or more DetailRecords can be added to an ABA file and remain within total record limits.
        /// </summary>
        public bool CanAdd(R.AbaFile file, params Records.DetailRecord[] records)
        {
            var list = new List<R.Records.DetailRecord>(file.DetailRecords);
            list.AddRange(records);
            foreach (var e in InternalValidate(list))
                return false;
            return true;
        }
    }
}

using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;
using Banking.AU.ABA.Validation.AbaFile;

namespace Banking.AU.ABA.Validation.Builtins
{
    /// <summary>
    /// Validates an entire AbaFile object.
    /// </summary>
    public class AbaFileValidator : IValidator<R.AbaFile>
    {
        private DetailRecordValidator _detailRecord;
        private FileTotalValidator _fileTotal;
        public AbaFileValidator()
        {
            _detailRecord = new DetailRecordValidator();
            _fileTotal = new FileTotalValidator();
        }

        public virtual void Clean(R.AbaFile item)
        {
            if (item.DescriptiveRecord == null)
                item.DescriptiveRecord = new Records.DescriptiveRecord();
            if (item.DetailRecords == null)
                throw new ArgumentNullException("DetailRecords must be provided.");

            foreach (var r in item.DetailRecords)
                _detailRecord.Clean(r);
            _fileTotal.Clean(item);
        }

        public virtual IEnumerable<Exception> Validate(R.AbaFile item)
        {
            if (item.DescriptiveRecord == null)
                yield return new ArgumentNullException("DescriptiveRecord must be provided");

            if (item.DetailRecords == null)
                yield return new ArgumentNullException("DetailRecords must be provided.");
            else
            {
                foreach (var r in item.DetailRecords)
                    foreach (var e in _detailRecord.Validate(r))
                        yield return e;
            }

            foreach (var e in _fileTotal.Validate(item))
                yield return e;
        }
    }
}

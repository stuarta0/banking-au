using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;
using Banking.AU.ABA.Validation.AbaFile;

namespace Banking.AU.ABA.Validation.Builtins
{
    public class AbaValidator : CompositeValidator<R.AbaFile>
    {
        private DetailRecordValidator _detailRecord;
        private FileTotalValidator _fileTotal;
        public AbaValidator()
        {
            base._validators = new List<IValidator<R.AbaFile>>()
            {
                new DebitTotalAmountValidator(),
                new CreditTotalAmountValidator(),
                new CountOfType1Validator()
            };
            _detailRecord = new DetailRecordValidator();
            _fileTotal = new FileTotalValidator();
        }

        public override void Clean(R.AbaFile item)
        {
            if (item.DescriptiveRecord == null)
                item.DescriptiveRecord = new Records.DescriptiveRecord();
            if (item.DetailRecords == null)
                throw new ArgumentNullException("DetailRecords must be provided.");
            if (item.FileTotalRecord == null)
                item.FileTotalRecord = item.GenerateTotalRecord();

            foreach (var r in item.DetailRecords)
                _detailRecord.Clean(r);
            _fileTotal.Clean(item.FileTotalRecord);

            // do any remaining cleaning from pipeline
            base.Clean(item);
        }

        public override IEnumerable<Exception> Validate(R.AbaFile item)
        {
            bool hasNull = false;
            if (item.DescriptiveRecord == null)
            {
                hasNull = true;
                yield return new ArgumentNullException("DescriptiveRecord must be provided");
            }

            if (item.DetailRecords == null)
            {
                hasNull = true;
                yield return new ArgumentNullException("DetailRecords must be provided.");
            }
            else
            {
                foreach (var r in item.DetailRecords)
                    foreach (var e in _detailRecord.Validate(r))
                        yield return e;
            }

            if (item.FileTotalRecord == null)
            {
                hasNull = true;
                yield return new ArgumentNullException("FileTotalRecord must be provided");
            }
            else
            {
                foreach (var e in _fileTotal.Validate(item.FileTotalRecord))
                    yield return e;
            }

            if (!hasNull)
            {
                // do any remaining validation from pipeline
                foreach (var e in base.Validate(item))
                    yield return e;
            }
        }
    }
}

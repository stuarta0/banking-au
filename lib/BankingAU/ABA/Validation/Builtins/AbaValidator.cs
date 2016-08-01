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
                new CountOfType1Validator()
            };
            _detailRecord = new DetailRecordValidator();
            _fileTotal = new FileTotalValidator();
        }

        public override void Clean(R.AbaFile item)
        {
            foreach (var r in item.DetailRecords)
                _detailRecord.Clean(r);
            _fileTotal.Clean(item.FileTotalRecord);

            // do any remaining cleaning from pipeline
            base.Clean(item);
        }

        public override IEnumerable<Exception> Validate(R.AbaFile item)
        {
            foreach (var r in item.DetailRecords)
                foreach (var e in _detailRecord.Validate(r))
                    yield return e;
            foreach (var e in _fileTotal.Validate(item.FileTotalRecord))
                yield return e;

            // do any remaining validation from pipeline
            foreach (var e in base.Validate(item))
                yield return e;
        }
    }
}

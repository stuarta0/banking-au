using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.Builtins
{
    public class AbaValidator : IValidator<AbaFile>
    {
        private DetailRecordValidator _detailRecord;
        private FileTotalValidator _fileTotal;
        public AbaValidator()
        {
            _detailRecord = new DetailRecordValidator();
            _fileTotal = new FileTotalValidator();
        }

        public void Clean(AbaFile item)
        {
            foreach (var r in item.DetailRecords)
                _detailRecord.Clean(r);
            _fileTotal.Clean(item.FileTotalRecord);
        }

        public IEnumerable<IError> Validate(AbaFile item)
        {
            foreach (var r in item.DetailRecords)
                foreach (var e in _detailRecord.Validate(r))
                    yield return e;
            foreach (var e in _fileTotal.Validate(item.FileTotalRecord))
                yield return e;
        }
    }
}

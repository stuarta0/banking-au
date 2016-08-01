using R = Banking.AU.ABA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    public class CountOfType1Validator : IValidator<R.AbaFile>
    {
        public void Clean(R.AbaFile item)
        {
            item.FileTotalRecord.CountOfType1 = item.DetailRecords.Count;
        }

        public IEnumerable<IError> Validate(R.AbaFile item)
        {
            if (item.FileTotalRecord.CountOfType1 != item.DetailRecords.Count)
                yield return new Error("CountOfType1 is incorrect");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.ABA.Validation.AbaFile
{
    /// <summary>
    /// Validator for calculating FileTotalRecord DebitTotalAmount from DetailRecords.
    /// </summary>
    public class DebitTotalAmountValidator : TotalAmountValidator
    {
        public DebitTotalAmountValidator()
            : base(Records.TransactionCode.DebitItem, 10,
                  f => f.FileTotalRecord.DebitTotalAmount,
                  (f,v) => f.FileTotalRecord.DebitTotalAmount = v)
        {
            _fieldName = "DebitTotalAmount";
        }
    }
}
